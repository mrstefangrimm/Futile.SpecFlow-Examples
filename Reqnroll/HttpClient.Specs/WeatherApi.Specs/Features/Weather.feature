@Weather
Feature: Weather

Scenario: Get weather forecast
	Given forecast from weather api
	When api is called
	Then forcast is in lower letters
