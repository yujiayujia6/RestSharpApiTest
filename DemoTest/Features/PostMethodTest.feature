Feature: CreateUser

Scenario Outline: Add users
	Given I input name <Name> and role <Role>
	When I send create user request
	Then validate user is created
Examples:
| Name  | Role |
| Tom   | QA   |
| Jerry | Dev  |
