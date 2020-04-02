Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be loggen in NewBookModel

@mytag
Scenario: Login to NewBookModels 
	Given Client is created
	And Sign in page is opened
	When I input email of created lead in email field
	And I input default password of created lead in password field
	And I press Log in button
	Then I successfully logged in NewBookModels site as created client
	