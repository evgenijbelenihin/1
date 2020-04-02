Feature: Updating User Profile
	In order to see a new actual profile data and avatar in my account
	As a client of NewBookModels
	I want to be able to change user profile data and avatar in Profile Settings

@mytag
Scenario: Update user profile data and avatar on NewBookModels site
	Given Client is created by API
	And I logged in NewBookModels by API
	And Account settings page is opened
	And Profile settings section in opened
	When I press Edit button
	And I fill the fields with data from the table
	| CompanyName | CompanyUrl  | Description           |
	| ytrewqq     | tbsdwtq.xxx | Some interesting info |
	And Avatar is chosen and uploaded
	And I press Save Changes button
	Then User avatar successfully changed
