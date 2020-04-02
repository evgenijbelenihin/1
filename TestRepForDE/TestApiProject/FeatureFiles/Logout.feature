Feature: Logout
	In order to be sure in the security of my account
	As a client of NewBookModels
	I want to be logged out of my account whenever I want

@mytag
Scenario: Logout from NewBookModels
	Given Client is created using API
	And I logged in NewBookModels using API
	When Account settings page is opened
	And I press Logout button
	Then I successfully logged out from NewBookModels