/**
 * Closes modal by id
 * @param {any} modalId
 */
window.closeModal = (modalId) => {
    $(modalId).hide();
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}

/**
 * Opens model by id
 * @param {any} modalId
 */
window.openModal = (modalId) => {
    $(modalId).modal('show');
}

/**
 * Scrolls to element by id
 * @param {any} elementId
 */
window.scrollToElement = (elementId) => {
    $('html, body').animate({
        scrollTop: $(elementId).offset().top - 120
    }, 500);
}

/**
 * hides element by id
 * @param {any} elementId
 */
window.hideElement = (elementId) => {
    $(elementId).addClass('d-none');
}

/**
 * shows element by id
 * @param {any} elementId
 */
window.showElement = (elementId) => {
    $(elementId).removeClass('d-none');
}

/**
 * Redirects to url
 * @param {any} url
 */
window.redirect = (url) => {
    window.location.replace(url);
}

/**
 * Toggles dropdown by id
 * @param {any} dropdownId
 */
window.toggleDropdown = (dropdownId) => {
    $(dropdownId).dropdown('toggle');
}

/**
 * Gets the share model
 * @param {*} title 
 * @param {*} text 
 * @param {*} url 
 * @param {*} modelId 
 */
window.share = (title, text, url, modelId) => {
    if (("share" in navigator)) {
        navigator.share({
            title: title,
            text: text,
            url: url
        });
        return;
    }

    $(modelId).modal('show');
}

/**
 * Provides ability to copy
 * @param {*} text 
 */
window.copyToClipboard = (text) => {
    navigator.clipboard.writeText(text);
}

// Initialize deferredPrompt for use later to show browser install prompt.
var evenInstallprompt;

/**
 * Stash the beforeinstallprompt event
 */
window.addEventListener('beforeinstallprompt', (e) => {
    evenInstallprompt = e;
});

/**
 * Is even install promptNull
 */
window.isEvenInstallpromptNull = () => {
    return evenInstallprompt == null;
}

/** 
 * Prompts pwa install
 */
window.promptPwaInstall = async () => {
    if (evenInstallprompt == null) {
        return;
    }

    evenInstallprompt.prompt();

    const { outcome } = await evenInstallprompt.userChoice;
    if (outcome === 'accepted') {
        evenInstallprompt = null;
    }
}

