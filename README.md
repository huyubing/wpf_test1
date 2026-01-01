"# wpf_test1

## Scientific Calculator with Theme Switching

A WPF-based scientific calculator application with support for multiple visual themes, calculation history, and a modern display.

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

### Calculation History

The calculator maintains a history of all calculations performed during the current session:
- **Automatic recording**: Each calculation is automatically added to the history panel
- **Easy reuse**: Click any history entry to load its result as the current value (sets Ans)
- **Session memory**: History persists for the duration of the app session
- **Clear function**: Use the "Clear History" button to reset the history list
- **Scrollable list**: The history panel scrolls automatically as more entries are added

The history panel is displayed on the right side of the calculator window, showing both the expression and result for each calculation.

### Modern Display Design

The calculator features a modern, eye-catching display area with:
- **Dark gradient background**: Deep blue gradient (from #1A1A2E to #0F3460)
- **Neon cyan text**: Bright cyan (#00D9FF) numbers for excellent readability
- **Glow effect**: Soft cyan glow around the text for a modern look
- **Gradient border**: Multi-color border with smooth transitions
- **Drop shadow**: 3D depth effect for visual appeal
- **Monospace font**: Consolas font for clean, aligned digits

The display maintains excellent readability across all themes while providing a contemporary, professional appearance.

### Improved Button Layout

The calculator features a compact, professional button layout:
- **No empty spaces**: All grid cells are utilized efficiently
- **6×6 grid**: Organized arrangement with scientific functions, numbers, and operators
- **Wide buttons**: The "0" and "=" buttons span multiple columns for ergonomic use
- **Responsive sizing**: Layout scales proportionally with window resizing
- **Logical grouping**: Functions organized by category (trigonometric, arithmetic, etc.)

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
