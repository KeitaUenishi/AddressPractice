$.validator.addMethod('blackword',
    function (value, element, param) {
        // 入力値が空の場合は無条件で成功
        value = $.trim(value);
        if (value === '') { return true; }

        // カンマ区切りでテキストを分解し、入力値Valueと順に比較
        var list = param.split(',');
        for (var i = 0, len = list.length; i < len; i++) {
            if (value.indexOf(list[i]) !== -1) {
                return false;
            }
        }
        return true;
    });

// blackword検証と、パラメーターoptsを登録
$.validator.unobtrusive.adapters.addSingleVal('blackword', 'opts');