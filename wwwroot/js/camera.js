var cameraStream;

export function startCamera() {
    navigator.mediaDevices.getUserMedia({ video: true })
        .then(stream => {
            cameraStream = stream;
            const videoElement = document.getElementById('videoElement'); // Make sure your video element has this ID
            videoElement.srcObject = stream;
        })
        .catch(error => {
            console.error('Error accessing camera:', error);
        });
}

export function takePhoto() {
    if (!cameraStream) {
        console.error('Camera stream not started.');
        return null;
    }

    const videoElement = document.getElementById('videoElement');
    const canvas = document.createElement('canvas');
    canvas.width = videoElement.videoWidth;
    canvas.height = videoElement.videoHeight;
    const context = canvas.getContext('2d');
    context.drawImage(videoElement, 0, 0, canvas.width, canvas.height);

    const imageDataUrl = canvas.toDataURL('image/png');
    return imageDataUrl; // Return the Base64 encoded image
}

export function stopCamera() {
    if (cameraStream) {
        cameraStream.getTracks().forEach(track => track.stop());
    }
}
export function playAlarm() {
    const alarmSound = document.getElementById('alarmSound');
    if (alarmSound) {
        alarmSound.play();
    }
}

export function pauseAlarm() {
    const alarmSound = document.getElementById('alarmSound');
    if (alarmSound) {
        alarmSound.pause();
        alarmSound.currentTime = 0; // Rewind to the beginning
    }
}


