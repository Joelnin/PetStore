let handler;

export function initHeroScroll(elementId) {
    const imgElement = document.getElementById(elementId);
    if (!imgElement) return;

    handler = function () {
        handleScroll(imgElement);
    };

    window.addEventListener('scroll', handler, { passive: true });
}

export function disposeHeroScroll() {
    if (handler) {
        window.removeEventListener('scroll', handler);
    }
}

function handleScroll(element) {
    requestAnimationFrame(() => {
        const scrolled = window.pageYOffset;

        const rate = 0.15;

        const offset = -(scrolled * rate);

        element.style.transform = `translate3d(0px, ${offset}px, 0px)`;
    });
}