var status;
$(document).ready(function() {

    /* DataTable Options Setting */
    tables = $('#table-areas').DataTable({
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
            "url" : "/area/getall",
            "type" : "GET",
            "datatype" : "json"
        },
        "columns" : [
            { "data" : null },
            { "data" : "name"},
            { "data" : function(data) {
                    return ( data.area_type == 0) ? "Vibrations" : "Operations";
                }
            },
            { "data" : function(data) {
                return ``+
                `<div class="text-center">
                    <button 
                        type="button" 
                        class="btn btn-outline-success btn-sm" 
                        onclick=edited('`+escape(JSON.stringify(data))+`')
                    >Edit</button>
                    <button 
                        type="button" 
                        class="btn btn-outline-danger btn-sm" 
                        onclick=deleted('/area/delete?id='+${data.id})
                    >Hapus</button>
                </div>`
            }}
        ]
    });
    $(".dataTables_filter").hide();
    $('#search-table').on('keyup', function () {
        tables.search( this.value ).draw();
    });
    tables.on( 'order.dt search.dt', function () {
        tables.column(0, {search:'applied', order:'applied'}).nodes().each( function (cell, i) {
            cell.innerHTML = i+1;
        } );
    } ).draw();
    /* Create User Modal Pop-Up */
    $("#btn-create").on("click", function(){
        $("#modal-create-areas").modal('show');
    });
    $('#modal-create-areas').on('shown.bs.modal', function (e) {
        $("#name").focus()
    });
    $('#modal-create-areas').on('hidden.bs.modal', function (e) {
        $("#name").val("");
        $("#type").val("");
        $(".error-name").html("");
        $(".error-type").html("");
    });

    $('#btn-save').on("click", function(e) {
        e.preventDefault();
        var name = $("#name").val();
        var type = $("#type").val();

        var error = false;

        if(_.isEmpty(name) || _.isUndefined(name)){
            error = true;
            $(".error-name").html("Nama harus diisi..!");
        }else{
            $(".error-name").html("");
        }

        if(_.isEmpty(type) || _.isUndefined(type)){
            error = true;
            $(".error-type").html("Type area harus diisi..!");
        }else{
            $(".error-type").html("");
        }

        if(!error){
            var parameter = {
                name : name,
                area_type : type,
                created_at : moment().format('YYYY-MM-DD HH:mm:ss'),
                updated_at : moment().format('YYYY-MM-DD HH:mm:ss'),
            }
            $("#btn-save").attr("disabled",true);
            $("#btn-save").text("");
            $("#btn-save").append('<i class="fas fa-sync-alt fa-spin"></i> Loading to save...');

            $.ajax({
                type : 'POST',
                url  : '/area/create',
                data : parameter,
                dataType : "JSON",
                success: function(response){
                    $("#btn-save").attr("disabled",false);
                    $("#btn-save").text("Save");
                    if(response.success){
                        toastr.success(response.message);
                        $("#modal-create-areas").modal("hide");
                        tables.ajax.reload();
                    }else{
                        toastr.error(response.message);
                    }
                }, error : function(err){
                    $("#btn-save").text("Save");
                    $("#btn-save").attr("disabled",false);
                    toastr.error("Internal Server Error !");
                }
            });
        }
    });
});

function edited(params){
    let user = JSON.parse(unescape(params)); 
}

function deleted(url){
    swal({
        title : "Yakin akan dihapus..?",
        text : "Jika dihapus, data tidak dapat dikembalikan..!",
        icon : "warning",
        buttons : true,
        dangerMode : true
    }).then((willDelete) => {
        if(willDelete){
            $.ajax({
                type : "DELETE",
                url : url,
                success : function(response){
                    if(response.success){
                        toastr.success(response.message);
                        tables.ajax.reload();
                    }else{
                        toastr.error(response.message);
                    }
                },
                error : function(err){
                    toastr.error("Internal Server Error !")
                }
            })
        }
    })
}

function updated(params){
    alert(params)
}