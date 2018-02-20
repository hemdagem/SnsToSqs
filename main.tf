provider "aws" {
  region = "eu-west-1"
}

module "pub-sub" {
  source = "pub-sub/"
}





