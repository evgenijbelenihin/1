Feature: Validation Sign In Fields
	In order to avoid silly mistakes
	As a client of NewBookModels
	I want to be informed that incorrect email or password was entered

@email
Scenario: Check validation of fields in Sign In page when incorrect format Email entered
	Given Sign In page is opened
	When Fill the Email field with incorrect format value 'qwert@qwe'
	And I change focus to password field element
	Then I see the error message about incorrect Email format

	@email
Scenario: Check validation of fields in Sign In page when empty Email entered
	Given Sign In page is opened
	When Fill the Email field with incorrect format value ''
	And I change focus to password field element
	Then I see the error message about incorrect Email format

	@email
Scenario: Check validation of fields in Sign In page when Email entered with special characters
	Given Sign In page is opened
	When Fill the Email field with incorrect format value '%##|||+)(^$^*@#@dwa.dqw'
	And I change focus to password field element
	Then I see the error message about incorrect Email format

	@email
Scenario: Check validation of fields in Sign In page when Email entered from digits
	Given Sign In page is opened
	When Fill the Email field with incorrect format value '12312312@123.123'
	And I change focus to password field element
	Then I see the error message about incorrect Email format

	@email
	Scenario: Check validation of fields in Sign In page when Email entered with two "@"
	Given Sign In page is opened
	When Fill the Email field with incorrect format value 'qwert@qwe.qwe@'
	And I change focus to password field element
	Then I see the error message about incorrect Email format

	@password
	Scenario: Check validation of fields in Sign In page when empty Password entered
	Given Sign In page is opened
	When Fill the Password field with incorrect format value ''
	And I change focus to Email element
	Then I see the error message about password required

