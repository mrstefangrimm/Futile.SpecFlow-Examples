Feature: Calculator

Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers headless
    Given headless profile is selected
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers in slow motion
    Given profile is selected with slowmo
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario Outline: Add two numbers permutations
    Given the first number is <FirstNumber>
    And the second number is <SecondNumber>
    When the two numbers are added
    Then the result should be <ExpectedResult>

Examples:
    | FirstNumber | SecondNumber | ExpectedResult |
    |           0 |            0 |              0 |
    |          -1 |           10 |              9 |
    |           6 |            9 |             15 |
