Feature: SignUp
	In order to Sign Up on the NewBookModels
	As a user who want to be a NewBookModels client
	I want to be registered on the NewBookModels


@mytag
Scenario: Sign Up on the NewBookModels
	Given Sign Up page is opened
	When I fill the fields with data from table
	| FirstName | LastName | Email          | Password   | ConfirmPassword | PhoneNumber|
	| John      | Doe      | 'Unique Email' | 123qweQWE! | 123qweQWE!      | 1231231239 |
	And I press Next button
	Then I successfully signed up on NewBookModels
