Feature: ReadTheMeal

@tag1
Scenario: read the meal
	Given I input category of meal
	When I send a read meal request
	Then verify that chosen category of meal is readed
