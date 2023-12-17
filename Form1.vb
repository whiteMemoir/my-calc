Public Class Form1

    ' Variable to store the current calculation
    Private currentCalculation As String = ""

    Private Sub DigitButton_Click(sender As Object, e As EventArgs) Handles button0.Click, button1.Click, button2.Click, button3.Click, button4.Click, button5.Click, button6.Click, button7.Click, button8.Click, button9.Click
        ' Handle digit button clicks
        Dim button As Button = DirectCast(sender, Button)
        AppendToCalculation(button.Text)
    End Sub

    Private Sub OperatorButton_Click(sender As Object, e As EventArgs) Handles buttonAddition.Click, buttonSubstraction.Click, buttonMultiplication.Click, buttonDivision.Click, buttonDecimal.Click, buttonLeftBracket.Click, buttonRightBracket.Click
        ' Handle operator button clicks
        Dim button As Button = DirectCast(sender, Button)
        AppendToCalculation(button.Text)
    End Sub

    Private Sub btnEquals_Click(sender As Object, e As EventArgs) Handles buttonEquals.Click
        ' Handle equals button click
        Try
            Dim result As Double = EvaluateExpression()
            textBoxOutput.Text = result.ToString()
            currentCalculation = result.ToString()
        Catch ex As Exception
            textBoxOutput.Text = "Error"
            currentCalculation = ""
        End Try
    End Sub

    Private Sub buttonClear_Click(sender As Object, e As EventArgs) Handles buttonClear.Click
        ' Handle clear button click
        ResetCalculator()
    End Sub

    Private Sub buttonClearEntry_Click(sender As Object, e As EventArgs) Handles buttonClearEntry.Click
        ' Handle clear entry button click
        If currentCalculation.Length > 0 Then
            currentCalculation = currentCalculation.Substring(0, currentCalculation.Length - 1)
            textBoxOutput.Text = currentCalculation
        End If
    End Sub

    Private Sub ResetCalculator()
        ' Reset the calculator to its initial state
        textBoxOutput.Text = "0"
        currentCalculation = ""
    End Sub

    Private Sub AppendToCalculation(value As String)
        ' Append the clicked button value to the current calculation
        currentCalculation += value
        textBoxOutput.Text = currentCalculation
    End Sub

    Private Function EvaluateExpression() As Double
        ' Evaluate the current calculation using DataTable Compute
        Dim formattedCalculation As String = currentCalculation.Replace("x", "*").Replace("÷", "/")
        Return CDbl(New DataTable().Compute(formattedCalculation, Nothing))
    End Function

End Class
