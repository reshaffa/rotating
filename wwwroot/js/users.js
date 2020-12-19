var status;
$(document).ready(function() {

    /* DataTable Options Setting */
    tables = $('#table-users').DataTable({
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
            "url" : "/user/getall",
            "type" : "GET",
            "datatype" : "json"
        },
        "columns" : [
            { "data" : "name"},
            { "data" : "email"},
            { "data" : "phone" },
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
                        onclick=deleted('/user/delete?id='+${data.id})
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
        $("#modal-create-users").modal('show');
    });
    $('#modal-create-users').on('shown.bs.modal', function (e) {
        $("#nip").focus()
    });

    $('#btn-save').on("click", function(e) {
        e.preventDefault();
        var nip = $("#nip").val();
        var name = $("#name").val();
        var email = $("#email").val();
        var phone = $("#phone").val();
        var role = $("#role").val();

        var error = false;

        if(_.isEmpty(nip) || _.isUndefined(nip)){
            error = true;
            $(".error-nip").html("Nip harus diisi..!");
        }else{
            if(_.isNaN(nip)){
                error = true;
                $(".error-nip").html("Nip kombinasi angka..!");
            }else{
                $(".error-nip").html("");
            }
        }

        if(_.isEmpty(name) || _.isUndefined(name)){
            error = true;
            $(".error-name").html("Nama harus diisi..!");
        }else{
            $(".error-name").html("");
        }

        if(_.isEmpty(email) || _.isUndefined(email)){
            error = true;
            $(".error-email").html("Email harus diisi..!");
        }else{
            $(".error-email").html("");
        }

        if(_.isEmpty(phone) || _.isUndefined(phone)){
            error = true;
            $(".error-phone").html("No. telp harus diisi..!");
        }else{
            $(".error-phone").html("");
        }

        if(_.isEmpty(role) || _.isUndefined(role)){
            error = true;
            $(".error-role").html("Silahkan pilih role..!");
        }else{
            $(".error-role").html("");
        }

        if(!error){
            var parameter = {
                nip : nip,
                name : name,
                email: email,
                phone: phone,
                role : role,
                password : 'PertaminaRU4',
                status: 1,
                created_at : moment().format('YYYY-MM-DD HH:mm:ss'),
                updated_at : moment().format('YYYY-MM-DD HH:mm:ss'),
            }
            $.ajax({
                type : 'POST',
                url  : '/user/create',
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