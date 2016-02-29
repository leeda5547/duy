Imports System.Data
Imports System.Data.SqlClient

Public Class QuanLyKhachHang
    Dim ketNoi As New SqlConnection("workstation id=duynpps02880.mssql.somee.com;packet size=4096;user id=duynp;pwd=123@admin;data source=duynpps02880.mssql.somee.com;persist security info=False;initial catalog=duynpps02880")

    Private Sub btnKetNoi_Click(sender As Object, e As EventArgs) Handles btnKetNoi.Click
        Try
            ketNoi.Open()
            MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ketNoi.Close()

        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub QuanLyKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()

    End Sub

    Private Sub loadData()
        ketNoi.Open()
        Dim command As New SqlCommand("select * from Khach_hang", ketNoi)
        Dim da As New SqlDataAdapter(command)
        Dim dt As New DataTable
        da.Fill(dt)
        ketNoi.Close()
        lsvQuanLyKhachHang.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In dt.Rows
            lsvQuanLyKhachHang.Items.Add(row("MaKH").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("TenKH").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("DiaChi").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("SoDienThoai").ToString())
            i += 1
        Next
    End Sub

    Private Sub lsvQuanLyKhachHang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvQuanLyKhachHang.SelectedIndexChanged
        For Each list As ListViewItem In lsvQuanLyKhachHang.SelectedItems
            txtMaKH.Text = list.SubItems(0).Text
            txtTenKH.Text = list.SubItems(1).Text
            txtDiaChi.Text = list.SubItems(2).Text
            txtSoDT.Text = list.SubItems(3).Text
        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            ketNoi.Open()
            Dim MaKH As String = txtMaKH.Text
            Dim TenKH As String = txtTenKH.Text
            Dim DiaChi As String = txtDiaChi.Text
            Dim SoDienThoai As String = txtSoDT.Text
            Dim command As New SqlCommand("insert into KHACH_HANG(MaKH, TenKH, DiaChi, SoDienThoai) values('" + MaKH + "',N'" + TenKH + "',N'" + DiaChi + "','" + SoDienThoai + "')", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Thêm dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Try
            ketNoi.Open()
            Dim MaKH As String = txtMaKH.Text
            Dim command As New SqlCommand("delete from KHACH_HANG where (MaKH='" + MaKH + "')", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Xóa dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Try
            ketNoi.Open()
            Dim MaKH As String = txtMaKH.Text
            Dim TenKH As String = txtTenKH.Text
            Dim DiaChi As String = txtDiaChi.Text
            Dim SoDienThoai As String = txtSoDT.Text
            Dim command As New SqlCommand("update KHACH_HANG set MaKH='" + MaKH + "', TenKH=N'" + TenKH + "', DiaChi=N'" + DiaChi + "',SoDienThoai='" + SoDienThoai + "' where MaKH='" + MaKH + "'", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Sửa dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class