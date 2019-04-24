$(function () {
    $.getJSON('https://api.banghasan.com/sholat/format/json/jadwal/kota/667/tanggal/2019-01-17', function (result) {
        console.log(result.jadwal.data);
        //alert(result.jadwal.data.dhuha);
        $("#tmSubuh").text(result.jadwal.data.subuh);
        $("#tmDzuhur").text(result.jadwal.data.dzuhur);
        $("#tmAshar").text(result.jadwal.data.ashar);
        $("#tmMaghrib").text(result.jadwal.data.maghrib);
        $("#tmIsya").text(result.jadwal.data.isya);

    });

    $.getJSON('https://api.banghasan.com/quran/format/json/surat/2/ayat/43', function (result) {
        console.log(result);        
        $("#ayat").text(result.ayat.data.ar[0].teks);
        var autSurat = result.surat.nama;
        var autAyat = result.ayat.data.ar[0].ayat;
        var arti = result.ayat.data.id[0].teks;
        $("#arti").text(arti.replace(parseInt(autAyat) + 1, autSurat + " : " + autAyat));

    });

    var pathAppointment = location.origin + "/Kegiatan/AppointmentDiary/IsMathAppointment/";
    $.ajax({
        data: {},
        cache: false,
        url: pathAppointment,
        //traditional: true,
        //type: 'POST',
        //dataType: "json",
        async: true,
        success: function (data) {
            if (data.success) {
                swal({
                    title: 'Malam ini adalah jadwal piket siskamling anda. Mohon hadir tepat waktu',
                    animation: true,
                    customClass: 'animated tada'
                })
            }
        },
        error: function (jqXHR, textStatus, errorMessage) {
            console.log(errorMessage);
        }
    });

})