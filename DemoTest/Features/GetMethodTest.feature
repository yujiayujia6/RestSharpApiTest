Feature: GetMethodTest

@tag1
Scenario: Get user list
	Given I send create user request
	Then validate user list get success
