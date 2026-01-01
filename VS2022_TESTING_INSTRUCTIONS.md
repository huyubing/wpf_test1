# VS2022 Manual Testing Guide - Scientific Calculator Enhancement

## Quick Start

### 1. Open in Visual Studio 2022
1. Open `SciCalc.sln` or `SciCalc/SciCalc.csproj` in VS2022
2. Press **F5** to build and run
3. The calculator window should appear at 750×650 pixels

### 2. Visual Verification

#### Expected Layout
```
┌───────────────────────────────────────────────────────────────────┐
│ 科学计算器                                                          │
├────────────────────────────────────────┬──────────────────────────┤
│ Theme: [Glass (Metallic) ▼]           │       History            │
├────────────────────────────────────────┼──────────────────────────┤
│                                      0 │                          │
│  ┌─────────────────────────────────┐  │  (Initially empty)       │
│  │                               0 │  │                          │
│  └─────────────────────────────────┘  │                          │
├────────────────────────────────────────┤                          │
│  ┌───┬───┬───┬───┬───┬───┐           │                          │
│  │sin│cos│tan│ln │log│exp│           │  [Clear History]         │
│  ├───┼───┼───┼───┼───┼───┤           └──────────────────────────┘
│  │ √ │x² │ ^ │ ! │ π │ e │           
│  ├───┼───┼───┼───┼───┼───┤           
│  │ ( │ ) │ % │ ± │Ans│ ⌫ │           
│  ├───┼───┼───┼───┼───┼───┤           
│  │ C │ 7 │ 8 │ 9 │ ÷ │ × │           
│  ├───┼───┼───┼───┼───┼───┤           
│  │   │ 4 │ 5 │ 6 │ - │ + │           
│  │ = ├───┼───┼───┼───┼───┤           
│  │   │ 1 │ 2 │ 3 │ 0 │ . │           
│  └───┴───┴───┴───┴───┴───┘           
└────────────────────────────────────────┘
```

#### Key Visual Checks
- ✅ NO empty/transparent buttons
- ✅ History panel visible on right side (200px width)
- ✅ Equals button spans 2 rows
- ✅ All 36 buttons visible and properly aligned
- ✅ Theme selector works
- ✅ Window is resizable

### 3. Functional Tests

#### Test 1: Basic Calculation
1. Click: `2` → `+` → `3` → `=`
2. **Expected Display:** `5`
3. **Expected History:** 
   ```
   2+3
   = 5
   ```

#### Test 2: Multiple Calculations
1. Click: `1` `0` → `×` → `5` → `=`
2. **Expected Display:** `50`
3. Click: `1` `0` `0` → `÷` → `4` → `=`
4. **Expected Display:** `25`
5. **Expected History (top to bottom):**
   ```
   100÷4
   = 25
   ───────
   10×5
   = 50
   ───────
   2+3
   = 5
   ```

#### Test 3: History Reuse
1. Click on the history item showing `= 50`
2. **Expected Display:** `50`
3. Click: `÷` → `2` → `=`
4. **Expected Display:** `25`
5. **Expected History:** New entry `50÷2 = 25` appears at top

#### Test 4: Scientific Functions
1. Click: `√` → `1` `6` → `)` → `=`
2. **Expected Display:** `4`
3. **Expected History:** `sqrt(16) = 4`

4. Click: `sin` → `0` → `)` → `=`
5. **Expected Display:** `0`
6. **Expected History:** `sin(0) = 0`

#### Test 5: Clear History
1. Click **Clear History** button
2. **Expected:** History list is empty
3. **Expected:** Calculator still works normally
4. Perform calculation: `5` → `+` → `5` → `=`
5. **Expected:** New history entry appears

#### Test 6: Theme Switching
1. Select "Light (Rounded Flat)" theme
2. **Expected:** Buttons change style
3. Select "Dark (Glowing)" theme
4. **Expected:** Buttons change to dark theme
5. Select "Glass (Metallic)" theme
6. **Expected:** Return to default metallic look
7. **Verify:** All themes work with new layout

#### Test 7: Window Resizing
1. Resize window larger
2. **Verify:** Buttons scale proportionally
3. **Verify:** History panel stays 200px width
4. Resize window to minimum size
5. **Verify:** Cannot resize below 750×650
6. **Verify:** Layout doesn't break at minimum size

### 4. Take Screenshots

#### Screenshot 1: Default State
- Capture the calculator at startup with empty history
- Save as: `calculator_default.png`

#### Screenshot 2: With History
- Perform several calculations (2+3, 10×5, 100÷4, sqrt(16))
- Capture showing history panel with multiple entries
- Save as: `calculator_with_history.png`

#### Screenshot 3: Different Theme
- Switch to "Dark (Glowing)" theme
- Capture to show theme compatibility
- Save as: `calculator_dark_theme.png`

#### Screenshot 4: Layout Comparison
- Take a full window screenshot showing:
  - Left side: Calculator with no empty cells
  - Right side: History panel with entries
- Save as: `calculator_full_layout.png`

### 5. Verification Checklist

Before marking as complete, verify:

- [ ] Application builds without errors
- [ ] Application runs without crashes
- [ ] All 36 buttons are visible (no empty cells)
- [ ] Calculator display shows calculations correctly
- [ ] History panel appears on right side
- [ ] History records calculations after pressing `=`
- [ ] Clicking history item populates display
- [ ] Clear History button removes all entries
- [ ] All number buttons (0-9) work
- [ ] All operator buttons (+, -, ×, ÷, ^) work
- [ ] All scientific functions work (sin, cos, tan, ln, log, exp, √, x²)
- [ ] Special buttons work ((, ), %, ±, !, π, e, Ans, ⌫, C)
- [ ] All 4 themes work correctly
- [ ] Window resizes properly
- [ ] Minimum window size enforced (750×650)
- [ ] Window title is "科学计算器"
- [ ] Layout looks professional with no gaps

### 6. Expected Results Summary

#### Build
```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

#### Visual
- Window: 750×650 pixels
- Two-column layout
- Left: Calculator (flexible width, 6×6 button grid)
- Right: History (200px fixed width)
- No empty button cells
- Professional appearance

#### Functional
- All existing calculator features work
- History updates after each calculation
- History items are clickable and reusable
- Clear History removes all entries
- Themes work with new layout

### 7. Common Issues and Solutions

#### Issue: Window too small
**Solution:** Check MinWidth/MinHeight are set to 750/650

#### Issue: History doesn't appear
**Solution:** Check Grid.Column="1" on history Border

#### Issue: Buttons have gaps
**Solution:** Verify Grid.Row and Grid.Column are correctly set

#### Issue: Can't click history items
**Solution:** Check SelectionChanged event is wired up

#### Issue: Theme doesn't apply
**Solution:** Verify CalculatorButtonStyle is in theme XAML files

### 8. Screenshots to Include in PR

After testing, upload these screenshots to the PR:

1. **calculator_default.png** - Shows initial state
2. **calculator_with_history.png** - Shows history functionality
3. **calculator_dark_theme.png** - Shows theme compatibility
4. **calculator_full_layout.png** - Shows complete layout

Add them to PR with:
```markdown
## Screenshots

### Default State
![Calculator Default](calculator_default.png)

### With History
![Calculator with History](calculator_with_history.png)

### Dark Theme
![Dark Theme](calculator_dark_theme.png)

### Full Layout
![Full Layout](calculator_full_layout.png)
```

---

## Test Report Template

After completing tests, fill out:

```markdown
## Test Results

**Tested by:** [Your Name]
**Date:** [Date]
**VS Version:** Visual Studio 2022 [Version Number]

### Build Status
- [ ] Builds successfully
- [ ] 0 Warnings
- [ ] 0 Errors

### Visual Verification
- [ ] No empty button cells
- [ ] History panel visible
- [ ] Professional appearance
- [ ] Window resizes correctly

### Functional Tests
- [ ] Basic calculations work
- [ ] History records calculations
- [ ] History items reusable
- [ ] Clear History works
- [ ] Scientific functions work
- [ ] All themes work

### Issues Found
[List any issues or none]

### Recommendation
- [ ] Ready to merge
- [ ] Needs fixes (list above)
```

---

## Merge to Main

Once all tests pass:

1. Go to GitHub PR page
2. Verify all checks are green
3. Add screenshots to PR description
4. Add test results
5. Click "Merge pull request"
6. Choose "Squash and merge" (recommended)
7. Confirm merge
8. Delete branch after merge (optional)
