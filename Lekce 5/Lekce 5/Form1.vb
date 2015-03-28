Public Class Form1

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'podle toho, která položka je vybraná, nastavit text do komponenty Label1 
        If ListBox1.SelectedIndex = 0 Then
            Label1.Text = "Dobrý den, Dobré ráno"
        ElseIf ListBox1.SelectedIndex = 1 Then
            Label1.Text = "Dobrý den, Dobré odpoledne"
        ElseIf ListBox1.SelectedIndex = 2 Then
            Label1.Text = "Nashledanou"
        ElseIf ListBox1.SelectedIndex = 3 Then
            Label1.Text = "Promiňte"
        ElseIf ListBox1.SelectedIndex = 4 Then
            Label1.Text = "Kde je ..."
        ElseIf ListBox1.SelectedIndex = 5 Then
            Label1.Text = "hotel"
        ElseIf ListBox1.SelectedIndex = 6 Then
            Label1.Text = "restaurace"
        ElseIf ListBox1.SelectedIndex = 7 Then
            Label1.Text = "nádraží"
        ElseIf ListBox1.SelectedIndex = 8 Then
            Label1.Text = "telefon"
        ElseIf ListBox1.SelectedIndex = 9 Then
            Label1.Text = "supermarket"
        ElseIf ListBox1.SelectedIndex = 10 Then
            Label1.Text = "záchod"
        End If
    End Sub
End Class
