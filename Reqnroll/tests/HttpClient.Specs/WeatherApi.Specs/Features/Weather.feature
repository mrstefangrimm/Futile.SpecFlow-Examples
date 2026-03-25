Feature: Weather

Scenario: Get weather forecast
    Given forecast from weather api
    When api is called
    Then forecast is in lower letters
