// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function readExcel(file){
    let promise = new Promise((resolve, reject) => {
        let fileReader = new FileReader();
        fileReader.readAsArrayBuffer(file);

        fileReader.onload = (e) => {
            let arrayBuffer = e.target.result;
            let wbook = XLSX.read(arrayBuffer, { type : 'buffer'})
            let wbookName = wbook.SheetNames[0];
            let wsheet = wbook.Sheets[wbookName];

            let data = XLSX.utils.sheet_to_json(wsheet,  { raw: false });
            resolve(data);
        }

        fileReader.onerror = ((error) => {
            reject(error);
        })
    })

    promise.then((d) => {
        let excel = []
        let temp = []
        d.map((el) => {
          
            let vib_max = (_.isEmpty(el.__EMPTY_31) || el.__EMPTY_31.trim() == "" ? 0 : el.__EMPTY_31.toString().replace(" (g)",""))
            let acc_max = (_.isEmpty(el.__EMPTY_32) || el.__EMPTY_32.trim() == "" ? 0 : el.__EMPTY_32.toString().replace(" (g)",""))
            let max_level = (_.isEmpty(el.__EMPTY_33) || el.__EMPTY_33.trim() == "" ? 0 : el.__EMPTY_33.toString().replace(" (g)",""))

            let actual_vib = (
                el.__EMPTY_38 == "A" && el.__EMPTY_39 == "D" ? parseFloat(vib_max) : 
                el.__EMPTY_38 == "N" && el.__EMPTY_39 == "A" || el.__EMPTY_39 == "D", el.__EMPTY_39 ? parseFloat(acc_max) :
                el.__EMPTY_38 == "N" && el.__EMPTY_39 == "N" ? parseFloat(max_level) : 0
            )

            temp.push({
                tag_no : el.__EMPTY_2,
                user_id : 1,
                area_name : el.__EMPTY_5,
                last_date : (_.isEmpty(el.__EMPTY_6) ? null : el.__EMPTY_6.toString()),
                dvr_ob : (_.isEmpty(el.__EMPTY_13) ? 0 : parseFloat(el.__EMPTY_13)),
                dvr_obv : (_.isEmpty(el.__EMPTY_14) ? 0 : parseFloat(el.__EMPTY_14)),
                dvr_obh : (_.isEmpty(el.__EMPTY_15) ? 0 : parseFloat(el.__EMPTY_15)),
                dvr_ib : (_.isEmpty(el.__EMPTY_16) ? 0 : parseFloat(el.__EMPTY_16)),
                dvr_ibv : (_.isEmpty(el.__EMPTY_17) ? 0 : parseFloat(el.__EMPTY_17)),
                dvr_ibh : (_.isEmpty(el.__EMPTY_18) ? 0 : parseFloat(el.__EMPTY_18)),
                dvr_a : (_.isEmpty(el.__EMPTY_19) ? 0 : parseFloat(el.__EMPTY_19)),
                dvn_ob : (_.isEmpty(el.__EMPTY_20) ? 0 :parseFloat( el.__EMPTY_20)),
                dvn_obv : (_.isEmpty(el.__EMPTY_21) ? 0 : parseFloat(el.__EMPTY_21)),
                dvn_obh : (_.isEmpty(el.__EMPTY_22) ? 0 : parseFloat(el.__EMPTY_22)),
                dvn_ib : (_.isEmpty(el.__EMPTY_23) ? 0 : parseFloat(el.__EMPTY_23)),
                dvn_ibv : (_.isEmpty(el.__EMPTY_24) ? 0 : parseFloat(el.__EMPTY_24)),
                dvn_ibh : (_.isEmpty(el.__EMPTY_25) ? 0 : parseFloat(el.__EMPTY_25)),
                dvn_a : (_.isEmpty(el.__EMPTY_26) ? 0 : parseFloat(el.__EMPTY_26)),
                dvr_max : (_.isEmpty(vib_max) ? 0 : parseFloat(vib_max)),
                dvn_max : (_.isEmpty(acc_max) ? 0 : parseFloat(acc_max)),
                max_level : (_.isEmpty(max_level) ? 0 : parseFloat(max_level)),
                actual_vib : parseFloat(actual_vib),
                position : (_.isEmpty(el.__EMPTY_37) || el.__EMPTY_37.trim() =="" ? "-" : el.__EMPTY_37),
                vib_status : (_.isEmpty(el.__EMPTY_38) || el.__EMPTY_38.trim() =="" ? "-" : el.__EMPTY_38),
                acc_status : (_.isEmpty(el.__EMPTY_39) || el.__EMPTY_39.trim() =="" ? "-" : el.__EMPTY_39),
                status : (_.isEmpty(el.__EMPTY_40) || el.__EMPTY_40.trim() =="" ? "-" : el.__EMPTY_40),
                indikasi : (_.isEmpty(el.__EMPTY_67) || el.__EMPTY_67.trim() =="" ? "-" : el.__EMPTY_67),
                type : (_.isEmpty(el.__EMPTY_68) || el.__EMPTY_68.trim() == "" ? "-" : el.__EMPTY_68),
                remark : (_.isEmpty(el.__EMPTY_69) || el.__EMPTY_69.trim() =="" ? "-" : el.__EMPTY_69),
                saran : (_.isEmpty(el.__EMPTY_70) || el.__EMPTY_70.trim() =="" ? "-" : el.__EMPTY_70)
            })
        })
        temp.splice(0,5)
        excel.push({
            filename : file.name,
            items : temp
        });
        document.getElementById("convert-uploads").value = JSON.stringify(excel);
    })
}

$(document).ready(function() {

    /* DataTable Options Setting */
    var tables = $('#table-vibrations').DataTable({
        "lengthChange": false,
        "searching": true,
        "zeroRecords":    "No matching records found",
        "paginate": {
            "first":      "First",
            "last":       "Last",
            "next":       "Next",
            "previous":   "Previous"
        },
        "ajax" : {
            "url" : "/vibration/getall",
            "type" : "GET",
            "datatype" : "json"
        },
        "columns" : [
            { "data" : "#" },
            { "data" : "Filename"},
            { "data" : "Description" },
            {
                "data" : "id",
                "render" : function(data){
                    return `<button class="btn btn-otline-danger btn-sm">Hapus</button>`
                }
            }
        ]
    });
    $(".dataTables_filter").hide();
    $('#search-table').on('keyup', function () {
        tables.search( this.value ).draw();
    });
    /* End DataTable Options Setting */

    /* Start Excel Plugin */
    $("#file-upload").on("change", function(e){
        var files = e.target.files[0];
        var fileName = e.target.files[0].name;
        //console.log(fileName)
        $('.custom-file-label').html(fileName);
        readExcel(files);
    })
    /* End Excel Plugin */
    /* Define Year into Select 2 */
    let finish_year = moment().year();
    let start_year = parseInt(finish_year) - 9
    let years = [
        { id : 0, text : "-- Pilih Tahun --" }
    ];
    for(start_year; start_year <= finish_year; --finish_year){
        years.push({ id : finish_year, text: finish_year});
    }
    $("#select-year").select2({
        data: years
    });

    /* Month Select 2 Function */
    let listMonth = [
        { id : 0, text : "-- Pilih Bulan --" },{ id : 1, text : "Januari" },{ id : 2, text : "Febuari" },
        { id : 3, text : "Maret" },{ id : 4, text : "April" },{ id : 5, text : "Mei" },{ id : 6, text : "Juni" },
        { id : 7, text : "Juli" },{ id : 8, text : "Agustus" },{ id : 9, text : "September" },
        { id : 10, text : "Oktober" },{ id : 11, text : "November" },{ id : 12, text : "Desember" }
    ];
    $("#select-month").select2({
        data: listMonth
    });

    /* Week Select 2 Function */
    let listWeek = [
        { id : 0, text : '-- Pilih Minggu --'},
        { id : 1, text : 'W - 1'},{ id : 2, text : 'W - 2'},
        { id : 3, text : 'W - 3'},{ id : 4, text : 'W - 4'},
        { id : 5, text : 'W - 5'},
    ]
    $("#select-week").select2({
        data : listWeek
    })

    $("#btn-uploads").on("click",function(e){
        e.preventDefault();

        var year = $("#select-year").val();
        var month = $("#select-month").val();
        var week = $("#select-week").val();
        var uploads = $("#convert-uploads").val();

        let error = false
        if(_.isEmpty(uploads) || _.isUndefined(uploads)){
            error = true;
            $(".error-uploads").html("Harap isikan file excel dengan format (.xlsx) !")
        }

        if(_.isEmpty(year) || _.isUndefined(year) || year == 0 ){
            error = true;
            $(".error-year").html("Tahun harus diisi..!")
        }

        if(_.isEmpty(month) || _.isUndefined(month) || month == 0 ){
            error = true;
            $(".error-month").html("Bulan harus diisi..!")
        }

        if(_.isEmpty(week) || _.isUndefined(week) || week == 0 ){
            error = true;
            $(".error-week").html("Week harus diisi..!")
        }

        if(!error){
            var data = JSON.parse(uploads);
            let config = moment(year.toString()).startOf('isoWeek').format('YYYY-MM-DD');
            let compare_date = moment(config).add(parseInt(month)-1,'month').add(parseInt(week),'week');
            let initial_date = moment(compare_date).format('YYYY-MM-DD')

            var parameter = {
                uploads : {
                    items : data[0].items,
                    filename : data[0].filename,
                },
                initial_date : initial_date,
                year : parseInt(year),
                month : parseInt(month),
                week : parseInt(week)
            }

            console.log(parameter)

            $("#btn-uploads").attr("disabled",true);
            $("#btn-uploads").text("");
            $("#btn-uploads").append('<i class="fas fa-sync-alt fa-spin"></i> Loading to save...');

            $.ajax({
                type : "POST",
                url : "/vibration/create",
                dataType : "JSON",
                data : parameter,
                success : function(response){
                    console.log(response)
                }, error : function(err){
                    $("#btn-uploads").attr("disabled",false);
                    $("#btn-uploads").text("Create");
                    toastr.error("Internal Server Error !")
                }
            })
        }
    });
});