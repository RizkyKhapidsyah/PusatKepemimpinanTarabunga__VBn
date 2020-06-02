Public Class Form1
    'aplikasi ini menampilkan sebuah laporan penjualan untuk
    'pusat kepemimpinan Tarabung 

    ' Class-level declarations
    Const intSUBSKRIPT_MAKS As Integer = 4              'subskript atas
    Dim strNamaProduk(intSUBSKRIPT_MAKS) As String      'nama produk
    Dim strPenjelasan(intSUBSKRIPT_MAKS) As String      'penjelasan
    Dim intNomorProd(intSUBSKRIPT_MAKS) As Integer      'nomor produk
    Dim decHarga(intSUBSKRIPT_MAKS) As Decimal          'harga per unit
    Dim intUnitTerjual(intSUBSKRIPT_MAKS) As Integer    'banyak unit terjual

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'menginisialisasi array dengan data produk
        AwalArray()
    End Sub

    Private Sub AwalArray()
        'menginisialisasi array
        'produk pertama
        strNamaProduk(0) = "Enam Langkah Kepemimpinan"
        strPenjelasan(0) = "Buku"
        intNomorProd(0) = 914
        decHarga(0) = 12950D

        'produk kedua
        strNamaProduk(1) = "Enam Langkah Kepemimpinan"
        strPenjelasan(1) = "CD"
        intNomorProd(1) = 915
        decHarga(1) = 14950D

        'produk ketiga
        strNamaProduk(2) = "Jalan Kesuksesan"
        strPenjelasan(2) = "Video"
        intNomorProd(2) = 916
        decHarga(2) = 18950D

        'produk keempat
        strNamaProduk(3) = "Tujuh Pelajaran Keberhasilan"
        strPenjelasan(3) = "Buku"
        intNomorProd(3) = 917
        decHarga(3) = 16950D

        'produk kelima
        strNamaProduk(4) = "Tujuh Pelajaran Keberhasilan"
        strPenjelasan(4) = "CD"
        intNomorProd(4) = 918
        decHarga(4) = 21950D
    End Sub


    Private Sub mnuFileKeluar_Click(sender As Object, e As EventArgs) Handles mnuFileKeluar.Click
        'menutup form
        Me.Close()
    End Sub

    Private Sub mnuLaporanMasukkan_Click(sender As Object, e As EventArgs) Handles mnuLaporanMasukkan.Click
        Dim intHitung As Integer = 0    'pencacah loop

        Do While intHitung <= intSUBSKRIPT_MAKS
            Try
                'membaca banyak unit terjual untuk sebuah produk
                intUnitTerjual(intHitung) = CInt(
                 InputBox("Masukkan banyak unit terjual dari nomor produk " &
                 intNomorProd(intHitung)))

                'menginkremen intHitung
                intHitung += 1
            Catch
                'pesan error untuk masukan tak valid
                MessageBox.Show("Masukkan integer.")
            End Try
        Loop
    End Sub

    Private Sub mnuLaporanTampilkan_Click(sender As Object, e As EventArgs) Handles mnuLaporanTampilkan.Click
        'menghitung dan menampilkan pendapatan untuk tiap
        'produk dan pendapatan total
        Dim intHitung As Integer
        Dim decPendapatan As Decimal
        Dim decPendapatanTotal As Decimal

        'menampilkan header laporan penjualan
        listDataPenjualan.Items.Add("LAPORAN PENJUALAN")
        listDataPenjualan.Items.Add("-------------------------")

        'menampilkan data penjualan untuk tiap produk
        For intHitung = 0 To intSUBSKRIPT_MAKS

            'menghitung pendapatan produk
            decPendapatan = intUnitTerjual(intHitung) * decHarga(intHitung)

            'menampilkan data produk
            listDataPenjualan.Items.Add("Nomor Produk: " &
            intNomorProd(intHitung))
            listDataPenjualan.Items.Add("Nama: " &
            strNamaProduk(intHitung))
            listDataPenjualan.Items.Add("Deskripsi: " &
            strPenjelasan(intHitung))
            listDataPenjualan.Items.Add("Harga Per Unit: " &
            "Rp. " & decHarga(intHitung).ToString())
            listDataPenjualan.Items.Add("Banyak Unit Terjual: " &
            "Rp. " & intUnitTerjual(intHitung).ToString())
            listDataPenjualan.Items.Add("Pendapatan Produk: " &
            "Rp. " & decPendapatan.ToString())
            listDataPenjualan.Items.Add("")

            'mengakumulasi pendapatan
            decPendapatanTotal = decPendapatanTotal + decPendapatan
        Next

        'menampilkan pendapatan total
        labelPendapatanTotal.Text = "Rp. " & decPendapatanTotal.ToString()
    End Sub

    Private Sub mnuHelpTentang_Click(sender As Object, e As EventArgs) Handles mnuHelpTentang.Click
        'menampilkan kotak tentang
        MessageBox.Show("Menampilkan laporan penjualan untuk PKT.", "Tentang")
    End Sub
End Class
