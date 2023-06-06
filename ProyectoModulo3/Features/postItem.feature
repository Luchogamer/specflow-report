Feature: postItem

A short summary of the feature

@tag1
Scenario: Do a post call to put an item on the demo store
	Given I have a valid auth token
	When I do a call on a post request
	Then I got a valid Ok code response
