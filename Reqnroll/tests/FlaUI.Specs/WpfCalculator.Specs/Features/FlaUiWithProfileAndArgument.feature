Feature: FlaUI with Profile and Argument
The WPF calculator uses the selected profile and takes the URL from the argument.

Scenario: Add two numbers using dynamic commandline arguments
    Given profile without argument and the commandline argument is "Hello arguments"
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
    And the title is set to "Hello arguments"
