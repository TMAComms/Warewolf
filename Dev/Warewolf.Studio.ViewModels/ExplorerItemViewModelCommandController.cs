using System;
using System.Linq;
using System.Windows;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Common.Interfaces.Versioning;
using Dev2.Studio.Core.Interfaces;
// ReSharper disable NonLocalizedString
// ReSharper disable InconsistentNaming

namespace Warewolf.Studio.ViewModels
{
    public class ExplorerItemViewModelCommandController
    {
        private static IShellViewModel _shellViewModel;
        static IPopupController _popupController;

        public ExplorerItemViewModelCommandController(IShellViewModel shellViewModel, IPopupController popupController)
        {
            _shellViewModel = shellViewModel;
            _popupController = popupController;
        }
        public void RollbackCommand(IExplorerRepository explorerRepository, IExplorerTreeItem parent, Guid resourceId, string versionNumber)
        {
            var output = explorerRepository.Rollback(resourceId, versionNumber);
            parent.AreVersionsVisible = true;
            parent.ResourceName = output.DisplayName;
        }

        internal void OpenCommand(ExplorerItemViewModel item, IServer server)
        {
            if (item.IsFolder)
            {
                item.IsExpanded = !item.IsExpanded;
            }
            else if (item.IsResourceVersion)
            {
                OpenVersionCommand(item.Parent.ResourceId,item.VersionInfo);
            }
            else
            {
                SetActiveStates(_shellViewModel, server);
                _shellViewModel.OpenResource(item.ResourceId, server);
            }                        
        }

        public void OpenVersionCommand(Guid resourceId, IVersionInfo versionInfo)
        {
            _shellViewModel.OpenVersion(resourceId, versionInfo);
        }

        public void NewServiceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewService(resourcePath);
        }

        public void NewDropboxSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewDropboxSource(resourcePath);
        }
        public void NewSharepointSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewSharepointSource(resourcePath);
        }
        public void NewRabbitMQSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewRabbitMQSource(resourcePath);
        }
        public void NewExchangeSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewExchangeSource(resourcePath);
        }
        public void NewEmailSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewEmailSource(resourcePath);
        }
        public void NewWebSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewWebSource(resourcePath);
        }
        public void NewPluginSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewPluginSource(resourcePath);
        }
        public void NewDatabaseSourceCommand(string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewDatabaseSource(resourcePath);
        }

        public void NewServerSourceCommand( string resourcePath, IServer server)
        {
            SetActiveStates(_shellViewModel, server);
            _shellViewModel.NewServerSource(resourcePath);
        }

        private static void SetActiveStates(IShellViewModel shellViewModel, IServer server)
        {
            shellViewModel.SetActiveEnvironment(server.EnvironmentID);
            shellViewModel.SetActiveServer(server);
        }

        public void ShowDependenciesCommand(Guid resourceId, IServer server)
        {
            _shellViewModel.ShowDependencies(resourceId, server);
        }

        public void DeleteVersionCommand(IExplorerRepository explorerRepository, ExplorerItemViewModel explorerItemViewModel, IExplorerTreeItem parent, string resourceName)
        {
            if (_popupController.ShowDeleteVersionMessage(resourceName) == MessageBoxResult.Yes)
            {
                explorerRepository.Delete(explorerItemViewModel);
                parent?.RemoveChild(parent.Children.First(a => a.ResourceName == resourceName));
            }
        }

        public void DeleteCommand(IEnvironmentModel environmentModel, IExplorerTreeItem parent, IExplorerRepository explorerRepository, ExplorerItemViewModel explorerItemViewModel, IPopupController popupController,IServer server)
        {
            try
            {
                if (explorerItemViewModel.IsResourceVersion)
                {
                    DeleteVersionCommand(explorerRepository, explorerItemViewModel, parent, explorerItemViewModel.ResourceName);
                }
                else
                {
                    if (environmentModel != null && popupController.Show(popupController.GetDeleteConfirmation(explorerItemViewModel.ResourceName)) == MessageBoxResult.Yes)
                    {
                        _shellViewModel.CloseResource(explorerItemViewModel.ResourceId, environmentModel.ID);
                        // Remove the item from the parent for studio change to show, then do the delete from the server.
                        parent?.RemoveChild(explorerItemViewModel);
                        //This Delete process is quite long and should happen after the studio change so that the user caqn continue without the studio hanging
                        var deletedFileMetadata = explorerRepository.Delete(explorerItemViewModel);
                        if (deletedFileMetadata.IsDeleted)
                        {
                            if (explorerItemViewModel.ResourceType == @"ServerSource" || explorerItemViewModel.IsServer)
                            {
                                server.UpdateRepository.FireServerSaved();
                            }
                        }
                        else
                        {
                            explorerItemViewModel.ResourceId = deletedFileMetadata.ResourceId;
                            explorerItemViewModel.ShowDependencies();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If the delete did not happen, we need to add the item back to the original state for studio changes to re-occur
                parent?.AddChild(explorerItemViewModel);
                explorerItemViewModel.ShowErrorMessage(ex.Message, @"Delete not allowed");
            }

            
        }

        internal void CreateFolderCommand(IExplorerRepository explorerRepository, string resourcePath, string name, Guid id)
        {
            explorerRepository.CreateFolder(resourcePath, name, id);
        }

        public ExplorerItemViewModel CreateChild(string name, Guid id, IServer server, ExplorerItemViewModel explorerItem, Action<IExplorerItemViewModel> selectAction)
        {
            var child = new ExplorerItemViewModel(server, explorerItem, selectAction, _shellViewModel, _popupController)
            {
                ResourceName = name,
                ResourceId = id,
                ResourceType = @"Folder",
                AllowResourceCheck = explorerItem.AllowResourceCheck,
                IsResourceChecked = explorerItem.IsResourceChecked,
                CanCreateFolder = explorerItem.CanCreateFolder,
                CanCreateSource = explorerItem.CanCreateSource,
                CanShowVersions = explorerItem.CanShowVersions,
                CanRename = explorerItem.CanRename,
                CanDeploy = explorerItem.CanDeploy,
                CanShowDependencies = explorerItem.CanShowDependencies,
                ResourcePath = explorerItem.ResourcePath + "\\" + name,
                CanCreateWorkflowService = explorerItem.CanCreateWorkflowService,
                ShowContextMenu = explorerItem.ShowContextMenu,
                IsSelected = true,
                IsRenaming = true,
                IsFolder = true
            };
            return child;
        }
    }
}