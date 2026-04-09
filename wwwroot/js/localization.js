export function getSavedLanguage() {
  return window.localStorage.getItem("petstore-language");
}

export function saveLanguage(language) {
  window.localStorage.setItem("petstore-language", language);
}
