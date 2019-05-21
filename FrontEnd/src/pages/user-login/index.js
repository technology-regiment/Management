import React, { Component } from 'react';
import { connect } from 'dva';
import { formatMessage, FormattedMessage } from 'umi/locale';
import Link from 'umi/link';
import { Checkbox, Alert, Icon } from 'antd';
import { Login } from 'ant-design-pro';
import styles from './style.less';

const { Tab, UserName, Password, Mobile, Captcha, Submit } = Login;

@connect(({ userLogin, loading }) => ({
  userLogin,
  submitting: loading.effects['userLogin/login'],
}))
class LoginPage extends Component {
  state = {
    type: 'account'
  };

  onTabChange = type => {
    this.setState({ type });
  };

  onGetCaptcha = () =>
    new Promise((resolve, reject) => {
      this.loginForm.validateFields(['mobile'], {}, (err, values) => {
        if (err) {
          reject(err);
        } else {
          const { dispatch } = this.props;
          dispatch({
            type: 'userLogin/getCaptcha',
            payload: values.mobile,
          })
            .then(resolve)
            .catch(reject);
        }
      });
    });

    login = ( values, callback) => {
      const { dispatch } = this.props;
      dispatch({
        type: 'userLogin/login',
        payload: {
          ...values
        },
        callback
      });
    };

  handleSubmit = (err, values) => {
    const { type } = this.state;
    if (!err) {
      this.login(values , () => {
         message.success("登陆成功");
      });
    }
  };


  renderMessage = content => (
    <Alert style={{ marginBottom: 24 }} message={content} type="error" showIcon />
  );

  render() {
    const { userLogin, submitting } = this.props;
    const { status, type: loginType } = userLogin;
    const { type } = this.state;
    return (
      <div className={styles.main}>
        <Login
          defaultActiveKey={type}
          onTabChange={this.onTabChange}
          onSubmit={this.handleSubmit}
          ref={form => {
            this.loginForm = form;
          }}
        >
          <Tab key="account" tab={formatMessage({ id: 'user-login.login.tab-login-credentials' })}>
            {status === 'error' &&
              !submitting &&
              this.renderMessage(formatMessage({ id: 'user-login.login.message-invalid-credentials' }))}
            <UserName
              name="Email"
              placeholder={'Email'}
              rules={[
                {
                  required: true,
                  message: '请输入邮箱',
                },
              ]}
            />
            <Password
              name="Password"
              placeholder={'Password'}
              rules={[
                {
                  required: true,
                  message: '请输入密码',
                },
              ]}
              onPressEnter={() => this.loginForm.validateFields(this.handleSubmit)}
            />
          </Tab>
          <Submit loading={submitting}>
            <FormattedMessage id="user-login.login.login" />
          </Submit>
         
        </Login>
      </div>
    );
  }
}

export default LoginPage;
