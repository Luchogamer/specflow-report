Feature: PostToken

A short summary of the feature

@PostTokenOk
Scenario: Post to obtain the token of api
	Given I have a valid url
	When I send a post request
	Then I got a valid code response
