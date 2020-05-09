Feature: Sign In
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@OpenSignInPage
Scenario: Does Sign In page open
	Given I have an URL
	When I open Sign In page
	Then Sign In page is opened

@DoesTitleOfPageExistWithName
Scenario: Does title of page exist with name
	Given I have an URL
	When I open Sign In page
	Then Title of page named 'Authorization'

@DoesLogoExist
Scenario: Does logo exist
	Given I have an URL
	When I open Sign In page
	Then Logo is displayed

@DoesEmailInputExist
Scenario: Does email input exist
	Given I have an URL
	When I open Sign In page
	Then Email input exist

@DoesPasswordInputExist
Scenario: Does password input exist
	Given I have an URL
	When I open Sign In page
	Then Password input exist

@DoesExistSignInButton
Scenario: Does exist Sign In button
	Given I have an URL
	When I open Sign In page
	Then Sign In button exist

@DoesExistSignUpButton
Scenario: Does exist Sign Up button
	Given I have an URL
	When I open Sign In page
	Then Sign Up button exist

@NameOfSignInButton
Scenario: Name of Sign In button
	Given I have an URL
	When I open Sign In page
	Then Name of Sign In button is 'SIGN IN'

@NameOfSignUpButton
Scenario: Name of Sign Up button
	Given I have an URL
	When I open Sign In page
	Then Name of Sign Up button is 'REGISTRATION'

@DoesPossibleToFillSymbolsToEmailField
Scenario: Does possible to fill 30 symbols to email field
	Given I open Sign In page
	When I fill 30 symbols to email input field
	Then In email input field is exist 30 symbols

@DoesPossibleToFillSymbolsToEmailField
Scenario: Does impossible to fill 31 symbols to email field
	Given I open Sign In page
	When I fill 31 symbols to email input field
	Then In email input field is exist 30 symbols

@DoesPossibleToFillSymbolsToPasswordField
Scenario: Does possible to fill 20 symbols to password field
	Given I open Sign In page
	When I fill 30 symbols to password input field
	Then In password input field is exist 30 symbols

@DoesPossibleToFillSymbolsToPasswordField
Scenario: Does possible to fill 5 symbols to password field
	Given I open Sign In page
	When I fill 5 symbols to password input field
	Then In password input field is exist 5 symbols

@DoesPossibleToFillSymbolsToPasswordField
Scenario: Does possible to fill 31 symbols to password field
	Given I open Sign In page
	When I fill 31 symbols to password input field
	Then In password input field is exist 30 symbols

@DoesPossibleToSignInWithAnyData
Scenario: Does possible to Sign In with not registered data
	Given I open Sign In page
	When I fill in email field 'blablabla@bla.bla'
	And I fill in password field 'blablabla'
	And I press Sign In button
	Then I do not sign in to account and got error

@DoesSymbolsHiddenInPasswordField
Scenario: Does symbols hidden in password field
	When I open Sign In page
	Then Password input field has password type

@DoesPossibleToSignInWithCorrectData
Scenario: Does possible to sign in with registered data
	Given I open Sign In page
	When I fill in email field 'qweqwe@qwe.qwe'
	And I fill in password field 'qweqwe'
	And I press Sign In button
	Then I successfully signed in

@DoesAfterClickSignUpButtonPageOpens
Scenario: Does after click Sign Up button page opens
	Given I open Sign In page
	When I press Sign Up button
	Then Sign Up page is opened

@DoesPossibleToSignInWithEmptyEmailField
Scenario: Does possible to sign in with empty email field
	Given I open Sign In page
	When I fill in email field ''
	And I fill in password field 'blablabla'
	And I press Sign In button
	Then I do not sign in to account and got error

@DoesPossibleToSignInWithEmptyPasswordField
Scenario: Does possible to sign in with empty password field
	Given I open Sign In page
	When I fill in email field 'blablabla@bla.bla'
	And I fill in password field ''
	And I press Sign In button
	Then I do not sign in to account and got error

@DoesExistForgotPasswordButton
Scenario: Does exist Forgot Password button
	Given I have an URL
	When I open Sign In page
	Then Forgot password button is exist

@DoesForgPassWindowOpens
Scenario:  Does Forgot Password window opens
	Given I open Sign In page
	When I press Forgot Password button
	Then Forgot Password modal window is opened

@DoesThemeChanges
Scenario:  Does theme changes in setting modal window
	Given I open Sign In page
	When I open Settings modal window
	And I chose new theme 'dark'
	Then Theme is changed to 'dark'

@ValidationErrorWhenFillIncorrectFormatEmail
Scenario: Does error displays when entered not valid data
	Given I open Sign In page
	When I fill in email field '123456qwerty'
	And I fill in password field 'blablabla'
	And I press Sign In button
	Then I do not sign in to account and got error

@DoesPossibleToFillDataInEmailFieldInEmailFormat
Scenario: Does possible to fill data in email field in email format like user@user.user
	Given I open Sign In page
	When I fill in email field 'blabla@bla.bla'
	Then Value in email field equals 'blabla@bla.bla'

@LabelOfEmailField
Scenario: Does email field have a properly label
	Given I have an URL
	When I open Sign In page
	Then Label of Email field is 'E-mail'

@LabelOfPasswordField
Scenario: Does password field have a properly label
	Given I have an URL
	When I open Sign In page
	Then Label of Password field is 'Password'

@ErrorWhenFillInvalidEmailData
Scenario: Does appear error when fill invalid data in email field
	Given I open Sign In page
	When I fill in email field '@@@@@@@@@@'
	And I fill in password field 'blablabla'
	And I press Sign In button
	Then I got error 'Incorrect e-mail or password'

@ErrorWhenFillInvalidPasswordData
Scenario: Does appear error when fill invalid data in password field
	Given I open Sign In page
	When I fill in email field 'qwe@qwe.qweqwe'
	And I fill in password field '$%^&*$%^&*%^&*('
	And I press Sign In button
	Then I got error 'Incorrect e-mail or password'

@CheckRestorePassword
Scenario Outline: Check that after the user has entered valid data, when we click on the "restore password" button, we see a message about sending a new password to the specified mail
	Given I open Sign In page
	And I press forgot password button
	When I fill email <Email> from table
	And I fill phone number <PhoneNumber> from table
	And I press Restore password button
	Then <Message> is displayed

	Examples:
		| Email                            | PhoneNumber   | Message                           |
		| 'evgenijbelenihin.don@gmail.com' | 0557817886    | 'Your password have been send!'   |
		| 'blablabla@bla.bla'              | 2582375923567 | 'Error'                           |
		| 'teacher@teacher.com'            | 0000000001    | 'Incorrect email or phone number' |
		| 'student@gmail.com'              | 0000000000    | 'Your password have been send!'   |
		| 'ms.marinkaaa17@gmail.com'       | 0501731362    | 'Your password have been send!'   |