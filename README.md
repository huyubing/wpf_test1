"# wpf_test1

## Scientific Calculator with Theme Switching

A WPF-based scientific calculator application with support for multiple visual themes.

### Features

- Full scientific calculator functionality including:
  - Basic arithmetic operations (+, -, ×, ÷)
  - Trigonometric functions (sin, cos, tan)
  - Logarithmic functions (ln, log)
  - Power and root operations (^, √, x²)
  - Factorial (!)
  - Mathematical constants (π, e)
  - Parentheses for complex expressions
  - Memory functions (Ans)

### Theme Switching

The calculator supports four distinct visual themes that can be switched at runtime using the theme selector in the top-right corner of the window:

#### Available Themes:

1. **Light (Rounded Flat)** - A clean, minimalist design with:
   - White buttons with soft gray borders
   - Rounded corners (12px radius)
   - Subtle hover effects
   - Modern flat design aesthetic

2. **Dark (Glowing)** - A dark mode with visual flair:
   - Dark gray buttons (#2D2D30 background)
   - White text on dark background
   - Blue glow effect on hover and press
   - Sharp corners with subtle rounding (5px)

3. **High Contrast** - Maximum visibility and accessibility:
   - Black background with bright yellow text
   - Bold yellow borders (2px)
   - High contrast color scheme for accessibility
   - Inverted colors on hover (yellow background, black text)
   - Square corners for sharp definition

4. **Glass (Metallic)** - A sophisticated translucent look:
   - Multi-layer gradient backgrounds
   - Light blue/cyan metallic appearance
   - Glass-like shine effect with inner highlight
   - Soft drop shadows
   - Smooth rounded corners (8px)

#### How to Switch Themes:

1. Launch the calculator application
2. Locate the "Theme:" dropdown selector in the top-right corner of the window
3. Click the dropdown to see all available themes
4. Select your preferred theme from the list
5. The button appearance updates immediately without requiring a restart

All calculator functionality remains fully operational regardless of which theme is selected. The theme affects only the visual appearance of the buttons.

### Building and Running

Requirements:
- .NET 8.0 or later
- Visual Studio 2022 (or any IDE with WPF support)

Build the project:
```bash
cd SciCalc
dotnet build
dotnet run
```
" 
