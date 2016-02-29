Imports System.Data
Imports System.Data.SqlClient


Public Class QuanLyBanHang
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


    Private Sub QuanLyBanHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()

    End Sub

    Private Sub loadData()
        ketNoi.Open()
        Dim command As New SqlCommand("select Hoa_don.MaHD, MaKH, Chi_Tiet_Hoa_Don.MaSP, TenSP, SoLuong, NgayTaoHD from HOA_DON inner join CHI_TIET_HOA_DON on Hoa_don.MaHD = CHI_TIET_HOA_DON.MaHD inner join SAN_PHAM on CHI_TIET_HOA_DON.MaSP = SAN_PHAM.MaSP", ketNoi)
        Dim da As New SqlDataAdapter(command)
        Dim dt As New DataTable
        da.Fill(dt)
        ketNoi.Close()
        lsvQuanLyKhachHang.Items.Clear()

        Dim i As Integer
        For Each row As DataRow In dt.Rows
            lsvQuanLyKhachHang.Items.Add(row("MaHD").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("MaKH").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("MaSP").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("TenSP").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("SoLuong").ToString())
            lsvQuanLyKhachHang.Items(i).SubItems.Add(row("NgayTaoHD").ToString())
            i += 1
        Next
    End Sub


    Private Sub lsvQuanLyKhachHang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvQuanLyKhachHang.SelectedIndexChanged
        For Each list As ListViewItem In lsvQuanLyKhachHang.SelectedItems
            txtMaHoaDon.Text = list.SubItems(0).Text
            txtMaKH.Text = list.SubItems(1).Text
            txtMaSanPham.Text = list.SubItems(2).Text
            txtSoLuong.Text = list.SubItems(4).Text
            txtNgayTaoHD.Text = list.SubItems(5).Text
        Next
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Try
            ketNoi.Open()
            Dim MaHoaDon As String = txtMaHoaDon.Text
            Dim MaKhachHang As String = txtMaKH.Text
            Dim MaSanPham As String = txtMaSanPham.Text
            Dim SoLuongSP As String = txtSoLuong.Text
            Dim NgayTaoHD As String = txtNgayTaoHD.Text

            Dim com1 As New SqlCommand("insert into HOA_DON(MaHD, NgayTaoHD, MaKH) values ('" + MaHoaDon + "', '" + NgayTaoHD + "','" + MaKhachHang + "')", ketNoi)
            com1.ExecuteNonQuery()

            Dim com2 As New SqlCommand("insert into CHI_TIET_HOA_DON(MaHD, MaSP, SoLuong) values ('" + MaHoaDon + "', '" + MaSanPham + "','" + SoLuongSP + "')", ketNoi)
            com2.ExecuteNonQuery()
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
            Dim MaHoaDon As String = txtMaHoaDon.Text
            Dim com1 As New SqlCommand("delete from CHI_TIET_HOA_DON where MaHD = '" + MaHoaDon + "' ", ketNoi)
            com1.ExecuteNonQuery()

            Dim com2 As New SqlCommand("delete from HOA_DON where MaHD ='" + MaHoaDon + "' ", ketNoi)
            com2.ExecuteNonQuery()
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
            Dim MaHoaDon As String = txtMaHoaDon.Text
            Dim MaKhachHang As String = txtMaKH.Text
            Dim MaSanPham As String = txtMaSanPham.Text
            Dim SoLuongSP As String = txtSoLuong.Text
            Dim NgayTaoHD As String = txtNgayTaoHD.Text
            Dim com1 As New SqlCommand("update HOA_DON set MaKH= '" + MaKhachHang + "', NgayTaoHD= '" + NgayTaoHD + "' where MaHD='" + MaHoaDon + "' ", ketNoi)
            com1.ExecuteNonQuery()

            Dim com2 As New SqlCommand("update CHI_TIET_HOA_DON set MaSP= '" + MaSanPham + "', SoLuong= '" + SoLuongSP + "' where MaHD='" + MaHoaDon + "' ", ketNoi)
            com2.ExecuteNonQuery()
            ketNoi.Close()
            MessageBox.Show("Sửa dữ liệu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
            loadData()
        Catch ex As Exception
            MessageBox.Show("Sửa dữ liệu không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

