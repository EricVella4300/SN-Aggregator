function getAccesstoken() {
    if (location.hash) {
        if (location.hash.splist('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                localStorage.setItem('accessToken', accessToken);
            }
        }
    }
}