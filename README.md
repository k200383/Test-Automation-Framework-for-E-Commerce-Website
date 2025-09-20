# E-Commerce Test Automation Framework

A comprehensive Selenium-based test automation framework built in C# using MSTest for validating e-commerce website functionality. This framework demonstrates automated testing best practices for web applications with a focus on login validation, shopping cart operations, and checkout workflows.

## Project Overview

This test automation framework validates the core functionality of the SauceDemo e-commerce website through automated testing. The framework is built using Selenium WebDriver with C# and MSTest, providing reliable and maintainable test automation for web applications.

## Framework Features

- Cross-browser testing support (Chrome, Firefox, Edge)
- Page Object Model design pattern implementation
- Configuration-driven test execution
- Comprehensive test coverage for critical user journeys
- Automated validation of login scenarios and error handling
- Shopping cart functionality testing
- End-to-end checkout process validation

## Test Coverage

The framework includes 14+ automated test cases covering:

### Login Validation Tests
- Valid username and password combinations
- Invalid credentials handling
- Empty field validations
- Error message verification

### Shopping Cart Operations
- Adding items to cart
- Removing items from cart
- Cart state management
- Product sorting functionality

### Checkout Workflows
- Checkout process navigation
- User information form validation
- Order completion verification

## Technology Stack

- Programming Language: C# (.NET Framework 4.7.2)
- Testing Framework: MSTest
- Web Automation: Selenium WebDriver 4.20.0
- Browser Drivers: ChromeDriver, GeckoDriver, MicrosoftDriver
- IDE: Visual Studio
- Configuration Management: App.config

## Framework Architecture

The framework follows the Page Object Model pattern for better maintainability and code reusability. Core components include:

- CorePage: Base class for WebDriver initialization and browser configuration
- Page Objects: Separate classes for each application page (LoginPage, HomePage, CheckoutPage)
- Test Classes: MSTest-based test execution classes
- Configuration: External configuration for browser selection and test parameters

## Browser Support

- Google Chrome (default)
- Mozilla Firefox
- Microsoft Edge

Browser selection is configurable through the App.config file, allowing easy switching between different browsers for cross-browser testing.

## Test Execution

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework 4.7.2
- NuGet Package Manager for dependency management

### Setup Instructions

1. Clone the repository to your local machine
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Update browser driver versions if needed
5. Configure target browser in App.config
6. Build the solution

### Running Tests

Execute tests through Visual Studio Test Explorer or use command line with MSTest runner:

```
dotnet test
```

Individual test methods can be executed independently, and the framework supports both single test execution and full test suite runs.

## Configuration

Browser configuration is managed through App.config:

```xml
<appSettings>
    <add key="Browser" value="Chrome" />
</appSettings>
```

Supported browser values: Chrome, Firefox, Edge

## Test Methods

### Login Test Cases
- `LoginWithValidUserValidPassword_TC001`: Validates successful login with correct credentials
- `LoginWithInvalidUserInvalidPassword_TC002`: Tests invalid username and password combination
- `LoginWithValidUserInvalidPassword_TC003`: Tests valid username with incorrect password
- `LoginWithInValidUserValidPassword_TC004`: Tests invalid username with correct password
- `LoginWithBlankUserValidPassword_TC005`: Validates username required error message
- `LoginWithValidUserBlankPassword_TC006`: Validates password required error message
- `LoginWithInValidUserBlankPassword_TC007`: Tests combination of invalid username and blank password
- `LoginWithBlankUserInvalidPassword_TC008`: Tests combination of blank username and invalid password

### Navigation and Cart Test Cases
- `GoToMenu_001`: Tests navigation menu functionality
- `AddItemToCart_002`: Validates adding products to shopping cart
- `RemoveItemFromCart_003`: Tests removing items from cart
- `SortProduct_004`: Validates product sorting functionality

### Checkout Test Cases
- `GoToCheckout_TC001`: Tests checkout process navigation
- `FillCheckoutInfo_TC002`: Validates complete checkout workflow with user information

## Test Data Management

The framework is designed to support external test data sources including XML files for data-driven testing scenarios. Test data can be parameterized for different test environments and user scenarios.

## Best Practices Implemented

- Page Object Model for maintainable test code
- Explicit waits for reliable element interactions
- Browser options configuration for consistent test execution
- Proper test setup and teardown methods
- Clear assertion messages for test result validation
- Modular test design for easy maintenance and updates

## Dependencies

Key NuGet packages used in the framework:

- MSTest.TestFramework (2.2.10)
- MSTest.TestAdapter (2.2.10)
- Selenium.WebDriver (4.20.0)
- Selenium.Support (4.20.0)
- Selenium.WebDriver.ChromeDriver (124.0.6367.20700)
- Selenium.WebDriver.GeckoDriver (0.34.0)
- Selenium.WebDriver.MicrosoftDriver (17.17134.0)
- Newtonsoft.Json (13.0.1)

## Contributing

This framework demonstrates professional test automation practices suitable for enterprise-level web application testing. The implementation focuses on reliability, maintainability, and comprehensive test coverage.

## Test Results

All test cases validate expected application behavior with proper assertion handling and error reporting. The framework provides detailed feedback on test execution results and failure analysis.

## Future Enhancements

- Integration with CI/CD pipelines
- Enhanced reporting with screenshots
- Parallel test execution capabilities
- Data-driven testing with external data sources
- Cross-platform testing support
