import { routerRedux } from 'dva/router';
import { getPageQuery } from './utils/utils';
import { setAuthority } from './utils/authority';
import { reloadAuthorized } from './utils/Authorized';
import * as loginService from './service';

export default {
  namespace: 'userLogin',

  state: { 
    loginUserInfo:{}
  },

  effects: {
    *login({ payload,callback }, { call }) {
      const loginUserInfo = yield call(loginService.login, payload);
          if(loginUserInfo!==false){
            if(callback){
              var storage = window.localStorage;
              storage["Name"] = loginUserInfo.Name;
              storage["SystemRoleName"] = loginUserInfo.SystemRoleName;
              storage["Email"] = loginUserInfo.Email;
              storage["AuthenticationToken"] = loginUserInfo.AuthenticationToken;
              storage['Id'] = loginUserInfo.Id;
              yield call(loginService.verification, {
                AuthenticationToken: loginUserInfo.AuthenticationToken
            });
            callback();
            }
          } 
        }, 
  },

  reducers: {
    
  },
};
