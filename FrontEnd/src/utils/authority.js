// use localStorage to store the authority info, which might be sent from server in actual project.
export function getAuthority(str) {
  // return localStorage.getItem('antd-pro-authority') || ['admin', 'user'];
  const authorityString =
    typeof str === 'undefined' ? localStorage.getItem('antd-pro-authority') : str;
  // authorityString could be admin, "admin", ["admin"]
  let authority;
  try {
    authority = JSON.parse(authorityString);
  } catch (e) {
    authority = authorityString;
  }
  if (typeof authority === 'string') {
    return [authority];
  }
  // return authority || ['admin'];
  return authority;
}

export function setAuthority(authority) {
  var storage = window.localStorage;
  storage["Name"] = authority.Name;
  storage["SystemRoleName"] = authority.SystemRoleName;
  storage["Email"] = authority.Email;
  storage["AuthenticationToken"] = authority.AuthenticationToken;
  storage['Id'] = authority.Id;
  return storage;
  // const proAuthority = typeof authority === 'string' ? [authority] : authority;
  // return localStorage.setItem('antd-pro-authority', proAuthority);
}
