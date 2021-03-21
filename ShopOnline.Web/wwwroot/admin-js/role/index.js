var RoleControl = function () {
    this.init = function () {
        loadData();
        RegisterEvent();
    }
    function RegisterEvent() {
        $('#btn-create').off('click').on('click', function () {
            $('#modal-add-edit').modal('show');
        })
        $('body').on('click', '.btn-edit', function () {
            var name = $(this).data('id');
            $('#hidId').val(name);
            $('#modal-add-edit').modal('show');
        });
        $('#btnSaveCreatRole').off('click').on('click', function () {
            var id = $('#hidId').val();
            var name = $('#txtNameRole').val();
            $.ajax({
                url: '/Admin/Role/CreatRole',
                type: 'Post',
                dataType: 'Json',
                data: {
                    RoleName: name,
                    RoleId: id
                }, success: function (res) {
                    if (res.status == true) {
                        if (id > 0) {
                            alert('Update is successfull');
                            window.location.href="/Admin/Role/Index"
                        }
                        else {
                            alert('Create is successfull');
                            window.location.href = "/Admin/Role/Index"
                        }
                    }
                }
            })
        })
        $('body').on('click', '.btn-grant', function () {
            $('#hidRoleId').val($(this).data('id'));
            var rolename = $('#hidRoleId').val();
            $.when(loadFunctionList())
                .done(fillPermission(rolename));
            $('#modal-grantpermission').modal('show');
        });
        $('#btnSavePermission').off('click').on('click', function () {
            var roleId = $('#hidRoleId').val();
            savepermission(roleId);
        })
    }
    function loadData(isPageChanged) {
        $('#ddlshowpage').on('change', function () {
            tedu.configs.pageSize = $(this).val();
            tedu.configs.pageIndex = 1;
            loadData(true);
        });
        $.ajax({
            url: '/Admin/Role/GetAllRolePaging',
            type: 'Post',
            dataType: 'Json',
            data: {
                keyword: $('#txtKeyword').val(),
                pageIndex: tedu.configs.pageIndex,
                pageSize: tedu.configs.pageSize
            },
            success: function (response) {
                var listUser = response.items;
                var ren = '';
                var template = $('#table-template').html();
                $.each(listUser, function (i, item) {
                    ren += Mustache.render(template, {
                        Id: item.id,
                        Name: item.name
                    })
                })
                $('#tbl-content').html(ren);
                wrapPaging(response.totalRecords, function () {
                    loadData();
                }, isPageChanged);
            }
        })
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / tedu.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                tedu.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
    function loadFunctionList(callback) {
        $.ajax({
            type: "Post",
            url: "/Admin/Function/GetAllFunction",
            dataType: "Json",
            success: function (response) {
                var template = $('#result-data-function').html();
                var render = "";
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.name,
                        treegridparent: item.parentId != null ? "treegrid-parent-" + item.parentId : "",
                        Id: item.id,
                    });
                });
                $('#lst-data-function').html(render);
                $('.tree').treegrid();
                $('#ckCheckAllView').on('click', function () {
                    $('.ckView').prop('checked', $(this).prop('checked'));
                });

                $('#ckCheckAllCreate').on('click', function () {
                    $('.ckAdd').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllEdit').on('click', function () {
                    $('.ckEdit').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllDelete').on('click', function () {
                    $('.ckDelete').prop('checked', $(this).prop('checked'));
                });

                $('.ckView').on('click', function () {

                    if ($('.ckView:checked').length == response.length) {
                        $('#ckCheckAllView').prop('checked', true);
                    } else {
                        $('#ckCheckAllView').prop('checked', false);
                    }
                });
                $('.ckAdd').on('click', function () {

                    if ($('.ckAdd:checked').length == response.length) {
                        $('#ckCheckAllCreate').prop('checked', true);
                    } else {
                        $('#ckCheckAllCreate').prop('checked', false);
                    }
                });
                $('.ckEdit').on('click', function () {
                    if ($('.ckEdit:checked').length == response.length) {
                        $('#ckCheckAllEdit').prop('checked', true);
                    } else {
                        $('#ckCheckAllEdit').prop('checked', false);
                    }
                });
                $('.ckDelete').on('click', function () {
                    if ($('.ckDelete:checked').length == response.length) {
                        $('#ckCheckAllDelete').prop('checked', true);
                    } else {
                        $('#ckCheckAllDelete').prop('checked', false);
                    }
                });

            },

        });
    }
    function fillPermission(roleId) {
        $.ajax({
            type: "Post",
            url: "/Admin/Role/GetPermissionFromRole",
            data: {
                RoleName: roleId
            },
            dataType: "json",
            success: function (response) {
                var litsPermission = response.data;
                $.each($('#tblFunction tbody tr'), function (i, item) {
                    $.each(litsPermission, function (j, jitem) {
                        if (jitem.functionId == $(item).data('id')) {
                            $(item).find('.ckView').first().prop('checked', jitem.canRead);
                            $(item).find('.ckAdd').first().prop('checked', jitem.canCreate);
                            $(item).find('.ckEdit').first().prop('checked', jitem.canUpdate);
                            $(item).find('.ckDelete').first().prop('checked', jitem.canDelete);
                        }
                    });
                });
            },
        });
        if ($('.ckView:checked').length == $('#tblFunction tbody tr .ckView').length) {
            $('#ckCheckAllView').prop('checked', true);
        } else {
            $('#ckCheckAllView').prop('checked', false);
        }
        if ($('.ckAdd:checked').length == $('#tblFunction tbody tr .ckAdd').length) {
            $('#ckCheckAllCreate').prop('checked', true);
        } else {
            $('#ckCheckAllCreate').prop('checked', false);
        }
        if ($('.ckEdit:checked').length == $('#tblFunction tbody tr .ckEdit').length) {
            $('#ckCheckAllEdit').prop('checked', true);
        } else {
            $('#ckCheckAllEdit').prop('checked', false);
        }
        if ($('.ckDelete:checked').length == $('#tblFunction tbody tr .ckDelete').length) {
            $('#ckCheckAllDelete').prop('checked', true);
        } else {
            $('#ckCheckAllDelete').prop('checked', false);
        }
    }
    function savepermission(idrole) {
        var data = [];
        $.each($('#lst-data-function tr'), function (i, item) {
            data.push({
                RoleId: idrole,
                FunctionId: $(item).data('id'),
                CanRead: $(item).find('.ckView').first().prop('checked'),
                CanDelete: $(item).find('.ckDelete').first().prop('checked'),
                CanUpdate: $(item).find('.ckEdit').first().prop('checked'),
                CanAdd: $(item).find('.ckAdd').first().prop('checked'),
            });
        })
        $.ajax({
            url: '/Admin/Role/UpdatPermission',
            type: 'Post',
            dataType: 'Json',
            data: {
                Value: data,
                roleName: idrole
            },
            success: function (res) {
                if (res.status == true) {
                    alert('Thành công');
                    window.location.href="/Admin/Role/Index"
                }
            }
        })
    }
}