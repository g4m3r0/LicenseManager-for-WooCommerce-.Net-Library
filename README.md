# LicenseManager for WooCommerce .Net Library
[![NuGet](https://img.shields.io/nuget/v/LicenseManager.svg)](https://www.nuget.org/packages/LicenseManager)
[![NuGet Downloads](https://img.shields.io/nuget/dt/LicenseManager.svg)](https://www.nuget.org/packages/LicenseManager)
[![Deploy to NuGet](https://github.com/g4m3r0/LicenseManager-for-WooCommerce-.Net-Library/actions/workflows/nuget.yml/badge.svg)](https://github.com/g4m3r0/LicenseManager-for-WooCommerce-.Net-Library/actions/workflows/nuget.yml)

A C# Library for the [LicenseManager for WooCommerce](https://github.com/wpexpertsio/license-manager-woocommerce) (formerly known as LicenseManager.at). This library makes it easy to activate or validate software licenses from .Net applications.

## Download / Nuget
Get the library from [NuGet](https://www.nuget.org/packages/LicenseManager/).
```
PM> NuGet\Install-Package LicenseManager -Version 1.0.4
```

## Minimal usage example
```c#
// Create a license manager (WordPress Host URL, Consumer API Key, Consumer API Secret)
var licenseManager = new("http://domain.com", "ck_3e68d6156f48ddb61b1748ca548f632b1d19d446", "cs_6a74509a3c4127bf19340ef873fd9349eca07g78");

// Activate a license key (this will increase the TimesActivated counter if successful)
var (success, errorMessage) = await _licenseManager.ActivateLicenseAsync(licenseKey, productId);

MessageBox.Show(success
                ? $"License {licenseKey} was successfully activated for product {productId}."
                : $"Something went wrong: {errorMessage}");
                
// Check if a license key is valid for a specific product
var (success, errorMessage) = await _licenseManager.ValidateLicenseAsync(licenseKey, productId);

MessageBox.Show(success
                ? $"License {licenseKey} was successfully validated for product {productId}."
                : $"Something went wrong: {errorMessage}");
```

## Example WinForms Project
You can find an example project at https://github.com/g4m3r0/LicenseManager-for-WooCommerce-.Net-Library-Example.

## Contributors
<a href="https://github.com/g4m3r0/LicenseManager-for-WooCommerce-.Net-Library/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=g4m3r0/LicenseManager-for-WooCommerce-.Net-Library" />
</a>

Made with [contrib.rocks](https://contrib.rocks).
