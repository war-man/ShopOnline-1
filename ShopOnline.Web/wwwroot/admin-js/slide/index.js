var SlideControl = function () {
    this.init = function () {
        loadData();
        registerEvent();
    }
    function registerEvent() {
        $('#btnSave').off('click').on('click', function () {
            var id = $('#hidIdM').val();
            var name = $('#txtNameM').val();
            var decripstion = $('#txtDescM').val();
            var pathImage = $('#txtImage').val();
            $.ajax({
                url: '/Admin/Slide/CreatSlide',
                type: 'Post',
                dataType: 'Json',
                data: {
                    Id: id,
                    Name: name,
                    Decripstion: decripstion,
                    PathImage: pathImage
                },
                success: function (res) {
                    if (res.status == true) {
                        if (id > 0) {
                            alert('Update is successfull');
                            window.location.href = "/Admin/Slide/Index"
                        }
                        else {
                            alert('Create is successfull');
                            window.location.href = "/Admin/Slide/Index"
                        }
                    }
                }
            })
        })
        $('#btn-create').off('click').on('click', function () {
            $('#modal-add-edit').modal('show');
        })
        $('body').on('click', '.btn-edit', function () {
            var id = $(this).data('id');
            $('#hidIdM').val(id);
            $('#modal-add-edit').modal('show');
        })
      
    }
    function loadData() {
        $.ajax({
            type: "Post",
            url: "/Admin/Slide/GetAllSlide",
              
            dataType: "json",
            success: function (response) {
                var listslide = response.data;
                var template = $('#table-template').html();
                var ren = '';
                $.each(listslide, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        Name: item.name,
                        PathImage: item.pathImage,
                    })
                })
                $('#tbl-content').html(ren);
            },
        });
    }
}