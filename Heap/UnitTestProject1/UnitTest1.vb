Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
<TestClass()> Public Class UnitTest1
    Dim h As New Heap.Heap
    <TestMethod()> Public Sub Checktest213()
        Dim p As New List(Of Integer)
        Dim p1 As New List(Of Integer)
        p1.AddRange({2, 1, 3})
        p = h.Check(1, p1)
        Dim str As New Text.StringBuilder
        For Each i As Integer In p
            str.Append(i)
        Next
        Assert.AreEqual("123", str.ToString)
    End Sub
    <TestMethod()> Public Sub Checktest()
        Dim p As New List(Of Integer)
        Dim p1 As New List(Of Integer)
        p1.Add(2)
        p1.Add(1)
        p1 = h.Check(1, p1)
        p1.Add(3)
        p1 = h.Check(2, p1)
        p1.Add(4)
        p1 = h.Check(3, p1)
        p1.Add(0)
        p1 = h.Check(4, p1)
        Dim str As New Text.StringBuilder
        For Each i As Integer In p1
            str.Append(i)
        Next
        Assert.AreEqual("01342", str.ToString)
    End Sub
    <TestMethod()> Public Sub checkSort()
        Dim int() As Integer = {10, 5, 7, 9, 3, 1, 2, 8, 4, 6}
        Assert.AreEqual(int, h.heapsort(int))
    End Sub
End Class