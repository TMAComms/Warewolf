﻿using Dev2.Activities.Designers2.RabbitMQ.Publish;
using Dev2.Activities.RabbitMQ.Publish;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Common.Interfaces.RabbitMQ;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Windows;

namespace Dev2.Activities.Designers.Tests.RabbitMQ.Publish
{
    [TestClass]
    // ReSharper disable InconsistentNaming
    public class RabbitMQPublishDesignerViewModelTest
    {
        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RabbitMQPublishDesignerViewModel_Constructor_NullModelItem_ThrowsException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(null, new Mock<IRabbitMQModel>().Object, new Mock<IEnvironmentModel>().Object);

            //------------Assert Results-------------------------
            Assert.IsNull(vm);
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RabbitMQPublishDesignerViewModel_Constructor_IEnvironmentModelIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), new Mock<IRabbitMQModel>().Object, null);

            //------------Assert Results-------------------------
            Assert.IsNull(vm);
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RabbitMQPublishDesignerViewModel_Constructor_IRabbitMQModelIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), null, new Mock<IEnvironmentModel>().Object);

            //------------Assert Results-------------------------
            Assert.IsNull(vm);
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Constructor")]
        public void RabbitMQPublishDesignerViewModel_Constructor()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), new Mock<IRabbitMQModel>().Object, new Mock<IEnvironmentModel>().Object);
            vm.QueueName = "Q1";
            vm.IsDurable = false;
            vm.IsExclusive = false;
            vm.IsAutoDelete = false;
            vm.Message = "Test Message";
            vm.Result = "Success";
            vm.IsRabbitMQSourceFocused = false;
            vm.IsQueueNameFocused = false;
            vm.IsMessageFocused = false;

            //------------Assert Results-------------------------
            Assert.IsNotNull(vm);
            Assert.IsNotNull(vm.EditRabbitMQSourceCommand);
            Assert.IsNotNull(vm.NewRabbitMQSourceCommand);
            Assert.IsTrue(vm.ShowLarge);
            Assert.AreEqual(vm.ThumbVisibility, Visibility.Visible);
            Assert.IsNotNull(vm.RabbitMQSources);
            Assert.IsFalse(vm.IsRabbitMQSourceFocused);
            Assert.IsFalse(vm.IsQueueNameFocused);
            Assert.IsFalse(vm.IsMessageFocused);
            Assert.IsNull(vm.SelectedRabbitMQSource);
            Assert.AreEqual(vm.QueueName, "Q1");
            Assert.AreEqual(vm.IsDurable, false);
            Assert.AreEqual(vm.IsExclusive, false);
            Assert.AreEqual(vm.IsAutoDelete, false);
            Assert.AreEqual(vm.Message, "Test Message");
            Assert.AreEqual(vm.Result, "Success");
            Assert.AreEqual(vm.IsRabbitMQSourceFocused, false);
            Assert.AreEqual(vm.IsQueueNameFocused, false);
            Assert.AreEqual(vm.IsMessageFocused, false);
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Constructor")]
        public void RabbitMQPublishDesignerViewModel_Validate()
        {
            //------------Setup for test--------------------------
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), new Mock<IRabbitMQModel>().Object, new Mock<IEnvironmentModel>().Object);
            vm.QueueName = "";
            vm.Message = null;
            vm.SelectedRabbitMQSource = null;

            //------------Execute Test---------------------------
            vm.Validate();

            //------------Assert Results-------------------------
            Assert.IsNotNull(vm);
            List<IActionableErrorInfo> errors = vm.Errors;
            Assert.IsNotNull(errors);
            Assert.AreEqual(3, errors.Count);
            StringAssert.Contains(errors[0].Message, "'RabbitMQ Source' cannot be null");
            StringAssert.Contains(errors[1].Message, "'Queue Name' cannot be empty or only white space");
            StringAssert.Contains(errors[2].Message, "'Message' cannot be empty or only white space");
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Commands")]
        public void RabbitMQPublishDesignerViewModel_EditRabbitMQSourceCommand_ShouldCallOpenResource()
        {
            //------------Setup for test--------------------------
            Mock<IRabbitMQModel> model = new Mock<IRabbitMQModel>();
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), model.Object, new Mock<IEnvironmentModel>().Object);
            //------------Execute Test---------------------------

            vm.EditRabbitMQSourceCommand.Execute(null);

            //------------Assert Results-------------------------
            Assert.IsNotNull(vm);
            model.Verify(p => p.EditSource());
        }

        [TestMethod]
        [Owner("Clint Stedman")]
        [TestCategory("RabbitMQPublishDesignerViewModelTest_Commands")]
        public void RabbitMQPublishDesignerViewModel_NewRabbitMQSourceCommand_ShouldPublishShowNewResourceWizard()
        {
            Mock<IRabbitMQModel> model = new Mock<IRabbitMQModel>();
            RabbitMQPublishDesignerViewModel vm = new RabbitMQPublishDesignerViewModel(CreateModelItem(), model.Object, new Mock<IEnvironmentModel>().Object);

            //------------Execute Test---------------------------
            vm.NewRabbitMQSourceCommand.Execute(null);

            //------------Assert Results-------------------------
            Assert.IsNotNull(vm);
            Assert.IsNull(vm.SelectedRabbitMQSource);
            Assert.IsFalse(vm.IsRabbitMQSourceSelected);
            model.Verify(p => p.CreateNewSource());
        }

        private static ModelItem CreateModelItem()
        {
            return ModelItemUtils.CreateModelItem(new DsfPublishRabbitMQActivity());
        }
    }

    // ReSharper restore InconsistentNaming
}