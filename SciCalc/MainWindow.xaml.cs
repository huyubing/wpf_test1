using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;

namespace SciCalc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string currentExpression = "";
    private double lastAnswer = 0;
    private bool shouldClearDisplay = false;
    private ObservableCollection<CalculationHistoryItem> calculationHistory = new ObservableCollection<CalculationHistoryItem>();

    public MainWindow()
    {
        InitializeComponent();
        HistoryListBox.ItemsSource = calculationHistory;
        LoadTheme("Glass"); // Load default theme
    }

    // History item class - internal to MainWindow
    private class CalculationHistoryItem
    {
        public string Expression { get; set; } = "";
        public string Result { get; set; } = "";
        public double NumericResult { get; set; }
    }

    private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ThemeComboBox.SelectedItem is ComboBoxItem item && item.Tag != null)
        {
            string themeName = item.Tag.ToString()!;
            LoadTheme(themeName);
        }
    }

    private void LoadTheme(string themeName)
    {
        // Load the appropriate theme resource dictionary
        string themeUri = $"/Themes/{themeName}Theme.xaml";
        ResourceDictionary theme = new ResourceDictionary
        {
            Source = new Uri(themeUri, UriKind.Relative)
        };

        // Clear existing merged dictionaries and add the new theme
        Resources.MergedDictionaries.Clear();
        Resources.MergedDictionaries.Add(theme);
    }

    private void UpdateDisplay()
    {
        DisplayTextBox.Text = string.IsNullOrEmpty(currentExpression) ? "0" : currentExpression;
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            currentExpression = "";
            shouldClearDisplay = false;
        }

        Button button = (Button)sender;
        string number = button.Tag.ToString() ?? "";
        currentExpression += number;
        UpdateDisplay();
    }

    private void OperatorButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            shouldClearDisplay = false;
        }

        Button button = (Button)sender;
        string op = button.Tag.ToString() ?? "";
        currentExpression += op;
        UpdateDisplay();
    }

    private void DecimalButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            currentExpression = "0";
            shouldClearDisplay = false;
        }

        // Prevent multiple decimals in one number
        if (!currentExpression.EndsWith("."))
        {
            currentExpression += ".";
        }
        UpdateDisplay();
    }

    private void FunctionButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            currentExpression = "";
            shouldClearDisplay = false;
        }

        Button button = (Button)sender;
        string function = button.Tag.ToString() ?? "";
        currentExpression += function + "(";
        UpdateDisplay();
    }

    private void ConstantButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            currentExpression = "";
            shouldClearDisplay = false;
        }

        Button button = (Button)sender;
        string constant = button.Tag.ToString() ?? "";
        if (constant == "pi")
        {
            currentExpression += "π";
        }
        else if (constant == "e")
        {
            currentExpression += "e";
        }
        UpdateDisplay();
    }

    private void FactorialButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            shouldClearDisplay = false;
        }

        currentExpression += "!";
        UpdateDisplay();
    }

    private void PercentButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            shouldClearDisplay = false;
        }

        currentExpression += "%";
        UpdateDisplay();
    }

    private void SignToggleButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(currentExpression))
        {
            // If expression starts with -, remove it; otherwise add it
            if (currentExpression.StartsWith("-"))
            {
                currentExpression = currentExpression.Substring(1);
            }
            else
            {
                currentExpression = "-" + currentExpression;
            }
            UpdateDisplay();
        }
    }

    private void AnsButton_Click(object sender, RoutedEventArgs e)
    {
        if (shouldClearDisplay)
        {
            currentExpression = "";
            shouldClearDisplay = false;
        }

        currentExpression += lastAnswer.ToString();
        UpdateDisplay();
    }

    private void BackspaceButton_Click(object sender, RoutedEventArgs e)
    {
        if (currentExpression.Length > 0)
        {
            currentExpression = currentExpression.Substring(0, currentExpression.Length - 1);
            UpdateDisplay();
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        currentExpression = "";
        UpdateDisplay();
    }

    private void EqualsButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string originalExpression = currentExpression;
            double result = EvaluateExpression(currentExpression);
            lastAnswer = result;
            
            // Add to history
            calculationHistory.Insert(0, new CalculationHistoryItem 
            { 
                Expression = originalExpression, 
                Result = $"= {result}",
                NumericResult = result
            });
            
            currentExpression = result.ToString();
            UpdateDisplay();
            shouldClearDisplay = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("错误: " + ex.Message, "计算错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void HistoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (HistoryListBox.SelectedItem is CalculationHistoryItem item)
        {
            // Use the stored numeric result instead of parsing the display string
            currentExpression = item.NumericResult.ToString();
            lastAnswer = item.NumericResult;
            UpdateDisplay();
            shouldClearDisplay = true;
            
            // Clear selection
            HistoryListBox.SelectedItem = null;
        }
    }

    private void ClearHistoryButton_Click(object sender, RoutedEventArgs e)
    {
        calculationHistory.Clear();
    }

    private double EvaluateExpression(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            return 0;
        }

        // Replace constants
        expression = expression.Replace("π", Math.PI.ToString());
        expression = expression.Replace("e", Math.E.ToString());

        // Process factorial first (before other operations)
        expression = ProcessFactorial(expression);

        // Process functions (sin, cos, tan, ln, log10, exp, sqrt)
        expression = ProcessFunctions(expression);

        // Process power operations (^)
        expression = ProcessPower(expression);

        // Process percent operations
        expression = ProcessPercent(expression);

        // Replace UI operators with standard ones
        expression = expression.Replace("×", "*");
        expression = expression.Replace("÷", "/");

        // Evaluate remaining expression using DataTable.Compute
        DataTable dt = new DataTable();
        var result = dt.Compute(expression, "");
        return Convert.ToDouble(result);
    }

    private string ProcessFactorial(string expression)
    {
        // Process factorial from right to left
        int pos;
        while ((pos = expression.LastIndexOf('!')) != -1)
        {
            // Find the number before !
            int start = pos - 1;
            while (start >= 0 && (char.IsDigit(expression[start]) || expression[start] == '.'))
            {
                start--;
            }
            start++;

            string numberStr = expression.Substring(start, pos - start);
            double number = double.Parse(numberStr);

            if (number < 0 || number > 170 || number != Math.Floor(number))
            {
                throw new InvalidOperationException("阶乘仅支持0到170之间的整数");
            }

            double factorial = CalculateFactorial((int)number);
            expression = expression.Substring(0, start) + factorial.ToString() + expression.Substring(pos + 1);
        }

        return expression;
    }

    private double CalculateFactorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    private string ProcessFunctions(string expression)
    {
        string[] functions = { "sin", "cos", "tan", "ln", "log10", "exp", "sqrt", "square" };

        foreach (string func in functions)
        {
            int pos;
            while ((pos = expression.IndexOf(func + "(")) != -1)
            {
                // Find matching closing parenthesis
                int openCount = 1;
                int i = pos + func.Length + 1;
                while (i < expression.Length && openCount > 0)
                {
                    if (expression[i] == '(') openCount++;
                    else if (expression[i] == ')') openCount--;
                    i++;
                }

                if (openCount != 0)
                {
                    throw new InvalidOperationException("括号不匹配");
                }

                string innerExpression = expression.Substring(pos + func.Length + 1, i - pos - func.Length - 2);
                double innerValue = EvaluateExpression(innerExpression);
                double result;

                switch (func)
                {
                    case "sin":
                        result = Math.Sin(innerValue);
                        break;
                    case "cos":
                        result = Math.Cos(innerValue);
                        break;
                    case "tan":
                        result = Math.Tan(innerValue);
                        break;
                    case "ln":
                        result = Math.Log(innerValue);
                        break;
                    case "log10":
                        result = Math.Log10(innerValue);
                        break;
                    case "exp":
                        result = Math.Exp(innerValue);
                        break;
                    case "sqrt":
                        result = Math.Sqrt(innerValue);
                        break;
                    case "square":
                        result = innerValue * innerValue;
                        break;
                    default:
                        throw new InvalidOperationException("未知函数: " + func);
                }

                expression = expression.Substring(0, pos) + result.ToString() + expression.Substring(i);
            }
        }

        return expression;
    }

    private string ProcessPower(string expression)
    {
        // Process power operations from left to right
        int pos;
        while ((pos = expression.IndexOf('^')) != -1)
        {
            // Find the base (left operand)
            int start = pos - 1;
            int parenCount = 0;
            if (start >= 0 && expression[start] == ')')
            {
                // Base is in parentheses
                parenCount = 1;
                start--;
                while (start >= 0 && parenCount > 0)
                {
                    if (expression[start] == ')') parenCount++;
                    else if (expression[start] == '(') parenCount--;
                    start--;
                }
                start++;
            }
            else
            {
                // Base is a number
                while (start >= 0 && (char.IsDigit(expression[start]) || expression[start] == '.' || expression[start] == '-'))
                {
                    start--;
                }
                start++;
            }

            // Find the exponent (right operand)
            int end = pos + 1;
            parenCount = 0;
            if (end < expression.Length && expression[end] == '(')
            {
                // Exponent is in parentheses
                parenCount = 1;
                end++;
                while (end < expression.Length && parenCount > 0)
                {
                    if (expression[end] == '(') parenCount++;
                    else if (expression[end] == ')') parenCount--;
                    end++;
                }
            }
            else
            {
                // Exponent is a number
                if (end < expression.Length && expression[end] == '-') end++;
                while (end < expression.Length && (char.IsDigit(expression[end]) || expression[end] == '.'))
                {
                    end++;
                }
            }

            string baseStr = expression.Substring(start, pos - start);
            string exponentStr = expression.Substring(pos + 1, end - pos - 1);

            double baseValue = EvaluateExpression(baseStr);
            double exponentValue = EvaluateExpression(exponentStr);
            double result = Math.Pow(baseValue, exponentValue);

            expression = expression.Substring(0, start) + result.ToString() + expression.Substring(end);
        }

        return expression;
    }

    private string ProcessPercent(string expression)
    {
        // Process percent operations
        int pos;
        while ((pos = expression.IndexOf('%')) != -1)
        {
            // Find the number before %
            int start = pos - 1;
            while (start >= 0 && (char.IsDigit(expression[start]) || expression[start] == '.'))
            {
                start--;
            }
            start++;

            string numberStr = expression.Substring(start, pos - start);
            double number = double.Parse(numberStr);
            double result = number / 100.0;

            expression = expression.Substring(0, start) + result.ToString() + expression.Substring(pos + 1);
        }

        return expression;
    }
}