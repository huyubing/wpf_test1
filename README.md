# wpf_test1

## Scientific Calculator with Theme Switching

### Language / 言語
- [English](#english)
- [日本語 (Japanese)](#日本語-japanese)

---

## English

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

The calculator features a modern, eye-catching display area that adapts to each theme:
- **Large monospace font**: Consolas 32pt font for clean, aligned digits
- **Theme-aware styling**: Display appearance changes to complement each theme
- **Modern effects**: Gradients, shadows, and glows appropriate to each theme
- **Excellent readability**: High-contrast text colors ensure visibility across all themes

Each theme provides its own unique display style:
- **Glass Theme**: Dark gradient background with neon cyan text and glow effect
- **Dark Theme**: Black background with white text and blue glow
- **Light Theme**: White gradient background with dark text and subtle shadow
- **High Contrast Theme**: Black background with bright yellow text for maximum accessibility

### Improved Button Layout

The calculator features a compact, professional button layout:
- **No empty spaces**: All grid cells are utilized efficiently
- **6×6 grid**: Organized arrangement with scientific functions, numbers, and operators
- **Extended = button**: The "=" button spans 2 rows for easy access
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
   - White gradient display with dark text

2. **Dark (Glowing)** - A dark mode with visual flair:
   - Dark gray buttons (#2D2D30 background)
   - White text on dark background
   - Blue glow effect on hover and press
   - Sharp corners with subtle rounding (5px)
   - Black display background with white text and blue glow

3. **High Contrast** - Maximum visibility and accessibility:
   - Black background with bright yellow text
   - Bold yellow borders (2px)
   - High contrast color scheme for accessibility
   - Inverted colors on hover (yellow background, black text)
   - Square corners for sharp definition
   - Black display with bright yellow text for maximum contrast

4. **Glass (Metallic)** - A sophisticated translucent look:
   - Multi-layer gradient backgrounds
   - Light blue/cyan metallic appearance
   - Glass-like shine effect with inner highlight
   - Soft drop shadows
   - Smooth rounded corners (8px)
   - Dark gradient display with neon cyan text and glow effects

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

---

## 日本語 (Japanese)

### テーマ切替機能付き科学計算機

WPF ベースの科学計算機アプリケーションです。複数のビジュアルテーマ、計算履歴、モダンなディスプレイをサポートしています。

### 機能

- 完全な科学計算機能：
  - 基本的な算術演算（+、-、×、÷）
  - 三角関数（sin、cos、tan）
  - 対数関数（ln、log）
  - 累乗と平方根（^、√、x²）
  - 階乗（!）
  - 数学定数（π、e）
  - 複雑な式のための括弧
  - メモリ機能（Ans）

### 計算履歴

計算機は現在のセッション中に実行されたすべての計算の履歴を保持します：
- **自動記録**：各計算は自動的に履歴パネルに追加されます
- **簡単な再利用**：履歴エントリをクリックすると、その結果が現在の値として読み込まれます（Ans を設定）
- **セッションメモリ**：履歴はアプリセッションの期間中保持されます
- **クリア機能**：「履歴をクリア」ボタンを使用して履歴リストをリセット
- **スクロール可能なリスト**：履歴パネルはエントリが追加されると自動的にスクロールします

履歴パネルは計算機ウィンドウの右側に表示され、各計算の式と結果の両方を表示します。

### モダンなディスプレイデザイン

計算機は各テーマに適応するモダンで目を引くディスプレイエリアを備えています：
- **大きな等幅フォント**：Consolas 32pt フォントで、きれいで整列された数字
- **テーマ対応スタイリング**：ディスプレイの外観は各テーマに合わせて変化
- **モダンなエフェクト**：各テーマに適したグラデーション、影、光彩
- **優れた可読性**：すべてのテーマで視認性を確保する高コントラストのテキストカラー

各テーマは独自のディスプレイスタイルを提供：
- **Glass テーマ**：ダークグラデーション背景にネオンシアンテキストと光彩効果
- **Dark テーマ**：ブラック背景にホワイトテキストとブルー光彩
- **Light テーマ**：ホワイトグラデーション背景にダークテキストと繊細な影
- **High Contrast テーマ**：最大限のアクセシビリティのためのブラック背景に明るいイエローテキスト

### 改善されたボタンレイアウト

計算機はコンパクトでプロフェッショナルなボタンレイアウトを特徴としています：
- **空のスペースなし**：すべてのグリッドセルが効率的に使用されます
- **6×6 グリッド**：科学関数、数字、演算子の整理された配置
- **拡張された = ボタン**：「=」ボタンは簡単にアクセスできるよう 2 行にまたがります
- **レスポンシブサイジング**：レイアウトはウィンドウのリサイズに比例してスケールします
- **論理的なグループ化**：機能はカテゴリ（三角関数、算術など）ごとにグループ化されます

### テーマ切り替え

計算機は、ウィンドウの右上にあるテーマセレクターを使用して実行時に切り替えることができる 4 つの異なるビジュアルテーマをサポートしています：

#### 利用可能なテーマ：

1. **Light（Rounded Flat）** - クリーンでミニマリストなデザイン：
   - ソフトグレーの境界線を持つホワイトボタン
   - 丸い角（12px 半径）
   - 繊細なホバー効果
   - モダンなフラットデザイン美学
   - ダークテキスト付きホワイトグラデーションディスプレイ

2. **Dark（Glowing）** - 視覚的な魅力を持つダークモード：
   - ダークグレーボタン（#2D2D30 背景）
   - ダーク背景にホワイトテキスト
   - ホバーとプレス時のブルー光彩効果
   - 繊細な丸み（5px）のシャープなコーナー
   - ホワイトテキストとブルー光彩のブラックディスプレイ背景

3. **High Contrast** - 最大限の視認性とアクセシビリティ：
   - ブラック背景に明るいイエローテキスト
   - 太いイエローの境界線（2px）
   - アクセシビリティのための高コントラストカラースキーム
   - ホバー時の反転カラー（イエロー背景、ブラックテキスト）
   - シャープな定義のための四角いコーナー
   - 最大限のコントラストのための明るいイエローテキストのブラックディスプレイ

4. **Glass（Metallic）** - 洗練された半透明の外観：
   - 多層グラデーション背景
   - ライトブルー/シアンのメタリックな外観
   - 内部ハイライト付きのガラスのような輝き効果
   - ソフトなドロップシャドウ
   - スムーズな丸い角（8px）
   - ネオンシアンテキストと光彩効果のダークグラデーションディスプレイ

#### テーマの切り替え方法：

1. 計算機アプリケーションを起動
2. ウィンドウの右上隅にある「Theme:」ドロップダウンセレクターを見つける
3. ドロップダウンをクリックして、利用可能なすべてのテーマを表示
4. リストから好みのテーマを選択
5. ボタンの外観は再起動なしで即座に更新されます

選択したテーマに関係なく、すべての計算機機能は完全に動作します。テーマはボタンの視覚的な外観にのみ影響します。

### ビルドと実行

必要条件：
- .NET 8.0 以降
- Visual Studio 2022（または WPF サポートのある IDE）

プロジェクトのビルド：
```bash
cd SciCalc
dotnet build
dotnet run
```

### 基本的な使用方法のヒント

1. **基本計算**：数字ボタンと演算子ボタンを使用して式を入力し、「=」を押して計算します
2. **科学関数**：三角関数、対数、累乗などの科学関数ボタンを使用します
3. **履歴の使用**：右側の履歴パネルで過去の計算を確認し、クリックして結果を再利用します
4. **Ans 機能**：「Ans」ボタンを使用して最後の計算結果を現在の式に挿入します
5. **テーマのカスタマイズ**：右上のテーマセレクターで好みのビジュアルスタイルを選択します
6. **履歴のクリア**：履歴パネルの「履歴をクリア」ボタンで履歴をリセットします

