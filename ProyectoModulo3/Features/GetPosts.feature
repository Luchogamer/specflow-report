Feature: Get posts

A short summary of the feature

@getOk
Scenario: Get some product by id
	Given I have a valid id
	When Isend a get request
	Then I spected a valid code response

