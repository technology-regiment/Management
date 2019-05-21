import { routerRedux } from 'dva/router';

import { setAuthority } from '@/utils/authority';
import { reloadAuthorized } from '@/utils/Authorized';
import { getPageQuery } from '@/utils/utils';
import * as loginService from './service';

export default {
  namespace: 'userLogin',

  state: { 
    loginUserInfo:{}
  },

  effects: {
    *login({ payload }, { put,call }) {
      const loginUserInfo = yield call(loginService.login, payload);
      const VerificationTokenInfo= yield call(loginService.verification, {AuthenticationToken: loginUserInfo.AuthenticationToken});
debugger;
      if (loginUserInfo.Name === VerificationTokenInfo.Name) {
        reloadAuthorized();
        debugger;
        const urlParams = new URL(window.location.href);
        const params = getPageQuery();
        let { redirect } = params;
        if (redirect) {
          const redirectUrlParams = new URL(redirect);
          if (redirectUrlParams.origin === urlParams.origin) {
            redirect = redirect.substr(urlParams.origin.length);
            if (redirect.match(/^\/.*#/)) {
              redirect = redirect.substr(redirect.indexOf('#') + 1);
            }
          } else {
            redirect = null;
          }
        }
        yield put(routerRedux.replace(redirect || '/'));
      }
          // if(loginUserInfo!==false){
          //   if(callback){
          //     var storage = window.localStorage;
          //     storage["Name"] = loginUserInfo.Name;
          //     storage["SystemRoleName"] = loginUserInfo.SystemRoleName;
          //     storage["Email"] = loginUserInfo.Email;
          //     storage["AuthenticationToken"] = loginUserInfo.AuthenticationToken;
          //     storage['Id'] = loginUserInfo.Id;
          //     const VerificationTokenInfo= yield call(loginService.verification, {
          //       AuthenticationToken: loginUserInfo.AuthenticationToken
          //   });
          //   callback();
          //   }
          // } 
        }, 
  },

  reducers: {
    
  },
};
