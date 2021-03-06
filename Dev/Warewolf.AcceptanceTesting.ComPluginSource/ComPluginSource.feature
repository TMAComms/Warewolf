﻿@ComPluginSource
Feature: ComPluginSource
	In order to create plugins
	As a Warewolf User
	I want to be able to select dlls as a source to be used

## New COMPlugin Source 
## Editing COMPlugin Source
## Change COMPlugin Source Assembly Input
## Refresh New COMPlugin Source
## load all dependancies after filter cleared 
@Ignore
Scenario: New COMPlugin Source File
Given I open New COMPlugin Source
Then "New COMPlugin Source" tab is opened
And title is "New Plugin Source"
And Footerlabel is ""
When I click 
	| Clicks                                   |
	| Development                              |
Then "Save" is "Enabled"
When I change Assembly to ""
Then "Save" is "Disabled"
When I change Assembly to "SomethingElse"
Then "Save" is "Enabled"
When I save as "Testing Resource Save"
Then the save dialog is opened
Then title is "Testing Resource Save"
And "Testing Resource Save" tab is opened
	
@Ignore
Scenario: Change Plugin Source Assembly Input
Given I open "Test File" plugin source
Then title is "Test File"
And FooterLabel value is ""
And "Save" is "Disabled"
When I click "Development"
Then FooterLabel value is "Development"
And "Save" is "Enabled"
When I save Plugin source
@Ignore
Scenario: load all dependancies after filter cleared 
Given I open New COMPlugin Source
And DLLs is "loading"
And I filter for "Development"
And "Development" is "Visible"
When I "clear" the filter
