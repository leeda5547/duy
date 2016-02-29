Imports System.Data
Imports System.Data.SqlClient


Public Class QuanLySanPham
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


    Private Sub QuanLySanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()

    End Sub

    Private Sub loadData()
        ketNoi.Open()
        Dim command As New SqlCommand("select * from SAN_PHAM", ketNoi)
        Dim da As New SqlDataAdapter(command)
        Dim dt As New DataTable
        da.Fill(dt)
        ketNoi.Close()
        lsvQuanLySanPham.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In dt.Rows
            lsvQuanLySanPham.Items.Add(row("MaSP").ToString())
            lsvQuanLySanPham.Items(i).SubItems.Add(row("TenSP").ToString())
            lsvQuanLySanPham.Items(i).SubItems.Add(row("DonGia").ToString())
            lsvQuanLySanPham.Items(i).SubItems.Add(row("MaLoaiSP").ToString())
            i += 1
        Next

    End Sub

    
    Private Sub lsvQuanLySanPham_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvQuanLySanPham.SelectedIndexChanged
        For Each list As ListViewItem In lsvQuanLySanPham.SelectedItems
            txtMaSanPham.Text = list.SubItems(0).Text
            txtTenSanPham.Text = list.SubItems(1).Text
            txtDonGiaSP.Text = list.SubItems(2).Text
            txtMaLoaiSP.Text = list.SubItems(3).Text
        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            ketNoi.Open()
            Dim MaSanPham As String = txtMaSanPham.Text
            Dim TenSanPham As String = txtTenSanPham.Text
            Dim DonGiaSP As String = txtDonGiaSP.Text
            Dim MaLoaiSP As String = txtMaLoaiSP.Text.ToUpper
            Dim command As New SqlCommand("insert into SAN_PHAM(MaSP, TenSP, DonGia, MaLoaiSP) values ('" + MaSanPham + "',N'" + TenSanPham + "','" + DonGiaSP + "','" + MaLoaiSP + "')", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Thêm dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Try
            ketNoi.Open()
            Dim MaSanPham As String = txtMaSanPham.Text
            Dim command As New SqlCommand("delete SAN_PHAM where MaSP='" + MaSanPham + "'", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Xóa dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Try
            ketNoi.Open()
            Dim MaSanPham As String = txtMaSanPham.Text
            Dim TenSanPham As String = txtTenSanPham.Text
            Dim DonGiaSP As String = txtDonGiaSP.Text
            Dim MaLoaiSP As String = txtMaLoaiSP.Text.ToUpper
            Dim command As New SqlCommand("Update SAN_PHAM set TenSP='" + TenSanPham + "', DonGia='" + DonGiaSP + "', MaLoaiSP='" + MaLoaiSP + "' where MaSP='" + MaSanPham + "'  ", ketNoi)
            command.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()

        Catch ex As Exception
            MessageBox.Show("Sửa dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class