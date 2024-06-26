mergeInto(LibraryManager.library, {
    GetDeviceType: function() {
        var userAgent = navigator.userAgent || navigator.vendor || window.opera;

        // Determine device type based on user agent
        if (/android/i.test(userAgent) || /iPad|iPhone|iPod/.test(userAgent)) {
            return allocate(intArrayFromString("Mobile"), 'i8', ALLOC_NORMAL);
        } else {
            return allocate(intArrayFromString("Desktop"), 'i8', ALLOC_NORMAL);
        }
    }
});
