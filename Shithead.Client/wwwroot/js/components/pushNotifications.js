//Origin see: https://github.com/dotnet-presentations/blazor-workshop/blob/master/src/BlazingPizza.ComponentsLibrary/wwwroot/pushNotifications.js

const applicationServerPublicKey = 'BJXtcLOGwb3OGYKRlLVDKnfte5GoVWMRPVSJfZ4iVuRb7QU8PrggkDA5Yf8kB10x_6CaJHukBfsGv_8qbNesymM';

/**
 * Subscribe to service worker
 * @param {any} worker
 */
async function subscribe(worker) {
    try {
        return await worker.pushManager.subscribe({
            userVisibleOnly: true,
            applicationServerKey: applicationServerPublicKey
        });
    } catch {
        return null;
    }
}

/**
 * Array buffer to Base64
 * @param {any} buffer
 */
function arrayBufferToBase64(buffer) {
    // https://stackoverflow.com/a/9458996
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;

    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }

    return window.btoa(binary);
}

/**
 * Gets push notification subscription
 * */
window.getpushNotificationSubscription = async () => {
    const worker = await navigator.serviceWorker.getRegistration();
    const existingSubscription = await worker.pushManager.getSubscription();

    //If there is an existing subscription use that
    if (existingSubscription) {
        return {
            url: existingSubscription.endpoint,
            p256dh: arrayBufferToBase64(existingSubscription.getKey('p256dh')),
            auth: arrayBufferToBase64(existingSubscription.getKey('auth'))
        };
    }

    //There is no subscription so promt the user for acces and create it
    const newSubscription = await subscribe(worker);
    if (newSubscription == null) {
        return null;
    }

    return {
        url: newSubscription.endpoint,
        p256dh: arrayBufferToBase64(newSubscription.getKey('p256dh')),
        auth: arrayBufferToBase64(newSubscription.getKey('auth'))
    };
};