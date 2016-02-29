Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Private Sub btnQuanLyKhachHang_Click(sender As Object, e As EventArgs) Handles btnQuanLyKhachHang.Click
        QuanLyKhachHang.Show()

    End Sub

    Private Sub btnQuanLyBanHang_Click(sender As Object, e As EventArgs) Handles btnQuanLyBanHang.Click
        QuanLyBanHang.Show()

    End Sub

    Private Sub btnQuanLySanPham_Click(sender As Object, e As EventArgs) Handles btnQuanLySanPham.Click
        QuanLySanPham.Show()
    End Sub

End Class
