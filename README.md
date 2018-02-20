# sns-to-sqs-terraform
Basic terraform to create an AWS Simple Notification Service (SNS) and Simple Queue Service (SQS)

## setup

### Install AWS command line tools

`choco install awscli -y`

## Setup aws

type `'aws configure'`

enter the following information when asked:

* `AWS Access Key ID [None]: Enter Key`
* `AWS Secret Access Key [None]: Enter Secret`
* `Default region name [None]: enter region e.g. eu-west-1`
* `Default output format [None]: format type e.g. json`

## Run terraform commands

* `terraform get` --get the module
* `terraform plan` -- setup the plan
* `terraform apply` -- run the script
