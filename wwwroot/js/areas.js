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
    /* Create User Modal Pop-Up */
    $("#btn-create").on("click", function(){
        $("#modal-create-areas").modal('show');
    });
    $('#modal-create-areas').on('shown.bs.modal', function (e) {
        $("#name").focus()
    });

    $('#btn-save').on("click", function(e) {
        e.preventDefault();
        var name = $("#name").val();
        var email = $("#type").val();

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
            $.ajax({
                type : 'POST',
                url  : '/area/create',
                data : parameter,
                dataType : "JSON",
                success: function(response){
                    if(response.success){
                        toastr.success(response.message);
                        tables.ajax.reload();
                    }else{
                        toastr.error(response.message);
                    }
                }, error : function(err){
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