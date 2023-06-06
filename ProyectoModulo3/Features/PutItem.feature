Feature: PutItem

A short summary of the feature

@PutOk
Scenario: Put in a product by id 
	Given I have a checked id  
	When I send a put request 
	Then I got an OK code response
