import request from '@/utils/request';

export async function fakeAccountLogin(params) {
  return request('/api/user-login/account', {
    method: 'POST',
    data: params,
  });
}
export function login(params) {
  return request.post('/api/login', { data: params });
}
export function verification(params) {
  return request.post('/api/verification', { data: params });
}
export async function getFakeCaptcha(mobile) {
  return request(`/api/user-login/captcha?mobile=${mobile}`);
}
