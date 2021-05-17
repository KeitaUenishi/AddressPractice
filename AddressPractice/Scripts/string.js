$.validator.addMethod('string',
    function (value, element, param) {
        value = $.trim(value);
        if (value === '') { return true; }

        var length = 0;
        for (var i = 0; i < value.length; i++) {
            var chr = value.charCodeAt(i);

            if ((chr >= 0x00 && chr < 0x81) ||
                (chr === 0xf8f0) ||
                (chr >= 0xff61 && chr < 0xffa0) ||
                (chr >= 0xf8f1 && chr < 0xf8f4)) {
                //半角文字の場合は1を加算
                length += 1;
            } else {
                //それ以外の文字の場合は2を加算
                length += 2;
            }
        }
        if (length <= 10) {
            return true;
        }       
        return false;
    });

$.validator.unobtrusive.adapters.addSingleVal('string', 'length');

